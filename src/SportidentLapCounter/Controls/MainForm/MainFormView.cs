using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Nancy;
using Nancy.Hosting.Self;
using SportidentLapCounter.DataTypes;
using SportidentLapCounter.Helpers;
using SPORTident;
using SPORTident.Common;
using System.Net.Sockets;
using SportidentLapCounter.Controls.CardInjectorForm;

namespace SportidentLapCounter.Controls.MainForm
{
    public partial class MainFormView : Form
    {
        private MainFormPresenter _presenter;

        private MainFormPresenter Presenter => _presenter ?? (_presenter = new MainFormPresenter());


        private NancyHost _host;
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
                SavePunchData(punchData);
            });
        }

        private void SavePunchData(CardPunchData punchData) {

            var sportidentCardnumber = punchData.Siid;
            if (!Presenter.Model.Teams.Where(x => x.SportidentCardNumber1 == sportidentCardnumber || x.SportidentCardNumber2 == sportidentCardnumber).ToList().Any())
            {
                Presenter.Model.Teams.Add(new Team { SportidentCardNumber1 = sportidentCardnumber });
            }

            foreach (var x in Presenter.Model.Teams.Where(x => x.SportidentCardNumber1 == sportidentCardnumber || x.SportidentCardNumber2 == sportidentCardnumber).ToList())
            {
                x.Laps += 1;
                x.LatestPunchTime = punchData.PunchDateTime;
            }

            SortUpdatePersist();
        }

        private void SortUpdatePersist()
        {
            Presenter.SortTeams();
            UpdateFromModel();
            dataGridView.ClearSelection();
            Presenter.PersistModel();
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
                columnSportidentCardNumber1.Visible = true;
                columnSportidentCardNumber2.Visible = true;
                columnLatestPunchTime.Visible = true;
                dataGridView.AllowUserToAddRows = true;
                dataGridView.RowHeadersVisible = true;
                FormBorderStyle = FormBorderStyle.Sizable;
                panelSettings.Visible = true;
                dataGridView.Top += panelSettings.Height;
                dataGridView.Height -= panelSettings.Height;
            }
            else
            {
                if (comboBox_sportidentDevices.Enabled)
                {
                    var result = MessageBox.Show(@"Vill du verkligen starta fullskärm utan att ha aktiverat Sportidentenheten?", @"Bekräfta", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        return;
                }
                columnSportidentCardNumber1.Visible = false;
                columnSportidentCardNumber2.Visible = false;
                columnLatestPunchTime.Visible = false;
                dataGridView.AllowUserToAddRows = false;
                dataGridView.RowHeadersVisible = false;
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                panelSettings.Visible = false;
                WindowState = FormWindowState.Maximized;
                dataGridView.Top -= panelSettings.Height;
                dataGridView.Height += panelSettings.Height;
                dataGridView.ClearSelection();
            }
        }

        private void PasteExcellData()
        {
            var rowsInClipboard = PasteHelper.SplitClipboardToRows();
            if (rowsInClipboard == null || rowsInClipboard.Length == 0)
                return;

            new List<Team>();
            foreach (var row in rowsInClipboard)
            {
                var valuesInRow = PasteHelper.SplitExcellRowToArray(row, 5);
                if (valuesInRow == null || valuesInRow.Length < 2)
                    continue;

                int number;
                if (!int.TryParse(valuesInRow[0], out number))
                    continue;

                var team = new Team
                {
                    Number = number,
                    Name = valuesInRow[1],
                };

                if (valuesInRow.Length >= 3)
                {
                    team.SportidentCardNumber1 = valuesInRow[2];
                }
                if (valuesInRow.Length >= 4)
                {
                    team.SportidentCardNumber1 = valuesInRow[3];
                }

                Presenter.Model.Teams.Add(team);
                SortUpdatePersist();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PasteExcellData();
        }

        private void buttonWebserverStart_Click(object sender, EventArgs e)
        {
            var port = textBoxPort.Text;
            int portInt;
            if (!int.TryParse(port, out portInt))
            {
                MessageBox.Show("Port måste vara numerisk!");
                return;
            }
            var url = $"http://localhost:{port}";
            _host = new NancyHost(new Uri(url));
            _host.Start();

            buttonWebserverStop.Enabled = true;
            buttonWebserverStart.Enabled = false;
        }

        private void buttonWebserverStop_Click(object sender, EventArgs e)
        {
            _host.Stop();
            buttonWebserverStop.Enabled = false;
            buttonWebserverStart.Enabled = true;
        }

        private void button_Fake_Click(object sender, EventArgs e)
        {
            var cardInjectForm = new CardInjectFormView();
            cardInjectForm.Show();
            cardInjectForm.CallbackMethod += Callback;
        }

        public void Callback(CardPunchData card)
        {
            SavePunchData(card);
        }
    }
}
