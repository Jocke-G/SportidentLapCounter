using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SportidentLapCounter.DataTypes;
using SPORTident;
using SPORTident.Common;

namespace SportidentLapCounter.Controls.MainForm
{
    public partial class MainFormView : Form
    {
        private MainFormPresenter _presenter;

        private MainFormPresenter Presenter => _presenter ?? (_presenter = new MainFormPresenter());


        private Reader _reader;

        public MainFormView()
        {
            InitializeComponent();
            InitializeSportidentReader();

            dataGridView.AutoGenerateColumns = false;

            UpdateFromModel();
            SetFontSize(Presenter.Model.FontSize);
        }

        private void InitializeSportidentReader()
        {
            _reader = new Reader
            {
                WriteBackupFile = true,
                BackupFileName = Path.Combine(Environment.CurrentDirectory, $@"backup\{DateTime.Now:yyyy-MM-dd}_stamps.bak")
            };

            _reader.OnlineStampRead += ReaderOnOnlineStampRead;
            _reader.ErrorOccured += Reader_ErrorOccured;
            GetSiDevices();
        }


        private void GetSiDevices()
        {
            ReaderDeviceInfo.GetAvailableDeviceList();
            foreach (var device in ReaderDeviceInfo.AvailableDevices)
            {
                comboBox_sportidentDevices.Items.Add(device);
            }
            if (comboBox_sportidentDevices.Items.Count > 0)
            {
                comboBox_sportidentDevices.SelectedIndex = 0;
            }
        }

        private void Reader_ErrorOccured(object sender, FileLoggerEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        private void ReaderOnOnlineStampRead(object sender, SportidentDataEventArgs e)
        {
            this.InvokeIfRequired(() =>
            {
                var punchData = e.PunchData.First();
                var sportidentCardnumber = punchData.Siid;
                if (!Presenter.Model.Teams.Where(x => x.SportidentCardNumber == sportidentCardnumber).ToList().Any())
                {
                    Presenter.Model.Teams.Add(new Team { SportidentCardNumber = sportidentCardnumber });
                }

                foreach (var x in Presenter.Model.Teams.Where(x => x.SportidentCardNumber == sportidentCardnumber).ToList())
                {
                    x.Laps += 1;
                    x.LatestPunchTime = punchData.PunchDateTime;
                }

                Presenter.SortTeams();

                UpdateFromModel();
                dataGridView.ClearSelection();

                Presenter.PersistModel();
            });
        }

        private void UpdateFromModel()
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = Presenter.Model.Teams;
        }

        private void Connect()
        {
            var readerDeviceInfo = (ReaderDeviceInfo)(comboBox_sportidentDevices.SelectedItem);
            _reader.InputDevice = readerDeviceInfo;
            _reader.OutputDevice = new ReaderDeviceInfo(ReaderDeviceType.None);
            _reader.OpenInputDevice();
            _reader.OpenOutputDevice();

            comboBox_sportidentDevices.Enabled = false;
            button_sportidentConnect.Enabled = false;
            button_sportidentDisconnect.Enabled = true;
        }

        private void button_sportidentConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_sportidentDisconnect_Click(object sender, EventArgs e)
        {
            _reader.CloseDevices();
            comboBox_sportidentDevices.Enabled = true;
            button_sportidentConnect.Enabled = true;
            button_sportidentDisconnect.Enabled = false;
        }


        private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Presenter.Model == null)
                return;

            Presenter.PersistModel();
        }

        private void RowAddedOrDeleted(object sender, DataGridViewRowEventArgs e)
        {
            Presenter.PersistModel();
        }

        private void buttonBigger_Click(object sender, EventArgs e)
        {
            Bigger();
        }

        private void Bigger()
        {
            var fontSize = dataGridView.DefaultCellStyle.Font.Size + 1;
            SetFontSize(fontSize);
            Presenter.PersistModel();
        }

        private void buttonSmaller_Click(object sender, EventArgs e)
        {
            Smaller();
        }

        private void Smaller()
        {
            var fontSize = dataGridView.DefaultCellStyle.Font.Size - 1;
            SetFontSize(fontSize);
            Presenter.PersistModel();
        }

        private void SetFontSize(float fontSize)
        {
            var font = new Font(dataGridView.DefaultCellStyle.Font.FontFamily, fontSize);
            dataGridView.DefaultCellStyle.Font = font;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = font;
            Presenter.Model.FontSize = fontSize;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Add) || keyData == (Keys.Control | Keys.Oemplus))
            {
                Bigger();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Subtract) || keyData == (Keys.Control | Keys.OemMinus))
            {
                Smaller();
                return true;
            }

            if (keyData == Keys.F11)
            {
                ToggleFullscreen();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonFullscreen_Click(object sender, EventArgs e)
        {
            ToggleFullscreen();
        }

        private void ToggleFullscreen()
        {
            if (FormBorderStyle == FormBorderStyle.None)
            {
                columnSportidentCardNumber.Visible = true;
                columnLatestPunchTime.Visible = true;
                dataGridView.AllowUserToAddRows = true;
                dataGridView.RowHeadersVisible = true;
                FormBorderStyle = FormBorderStyle.Sizable;
                panelSettings.Visible = true;
                dataGridView.Location = new Point(12, 86);
            }
            else
            {
                if (comboBox_sportidentDevices.Enabled)
                {
                    var result = MessageBox.Show(@"Vill du verkligen starta fullskärm utan att ha aktiverat Sportidentenheten?", @"Bekräfta", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        return;
                }
                columnSportidentCardNumber.Visible = false;
                columnLatestPunchTime.Visible = false;
                dataGridView.AllowUserToAddRows = false;
                dataGridView.RowHeadersVisible = false;
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                panelSettings.Visible = false;
                WindowState = FormWindowState.Maximized;
                dataGridView.Location = new Point(12, 12);
                dataGridView.ClearSelection();
            }
        }
    }
}
