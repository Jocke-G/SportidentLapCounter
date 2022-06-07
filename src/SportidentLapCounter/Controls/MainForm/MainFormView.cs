using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Nancy.Hosting.Self;
using SPORTident;
using SportidentLapCounter.DataTypes;
using SportidentLapCounter.Helpers;
using SportidentLapCounter.Controls.CardInjectorForm;
using SportidentLapCounter.Controls.VerificationForm;
using SportidentLapCounter.Services;
using SPORTident.Communication.UsbDevice;

namespace SportidentLapCounter.Controls.MainForm
{
    public partial class MainFormView : Form
    {
        private MainFormPresenter _presenter;

        private MainFormPresenter Presenter => _presenter ?? (_presenter = new MainFormPresenter());
        private NancyHost _host;
        private readonly ISportIdentService _deviceService = new SportIdentService();
        private VerificationFormView _verificationForm;

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
            GetSiDevices();
            _deviceService.RadioPunch += OnRadioPunch;
            _deviceService.CardReadout += OnCardReadout;
        }

        private void GetSiDevices()
        {
            comboBox_sportidentDevices.Items.Clear();
            var devices = _deviceService.GetAllDevices();
            foreach (var device in devices)
            {
                comboBox_sportidentDevices.Items.Add(device);
            }
            if (comboBox_sportidentDevices.Items.Count > 0)
            {
                comboBox_sportidentDevices.SelectedIndex = 0;
            }
        }

        private void OnRadioPunch(object sender, CardPunchData e)
        {
            this.InvokeIfRequired(() =>
            {
                SavePunchData(e);
            });
        }

        private void OnCardReadout(object sender, SportidentCard e)
        {
            this.InvokeIfRequired(() =>
            {
                SaveReadout(e);
            });
        }

        private void SaveReadout(SportidentCard card)
        {

            var sportidentCardnumber = card.Siid;
            if (!Presenter.Model.Teams.Where(x => x.SportidentCardNumber1 == sportidentCardnumber || x.SportidentCardNumber2 == sportidentCardnumber).ToList().Any())
            {
                Presenter.Model.Teams.Add(new Team { SportidentCardNumber1 = sportidentCardnumber });
            }

            foreach (var team in Presenter.Model.Teams.Where(x => x.SportidentCardNumber1 == sportidentCardnumber || x.SportidentCardNumber2 == sportidentCardnumber).ToList())
            {
                team.Laps = card.ControlPunchList.Count;
                team.LatestPunchTime = card.ControlPunchList.Last().PunchDateTime;

                _verificationForm?.ShowPunch(team);
            }

            SortUpdatePersist();
        }

        private void SavePunchData(CardPunchData punchData) {

            var sportidentCardnumber = punchData.Siid;
            if (!Presenter.Model.Teams.Where(x => x.SportidentCardNumber1 == sportidentCardnumber || x.SportidentCardNumber2 == sportidentCardnumber).ToList().Any())
            {
                Presenter.Model.Teams.Add(new Team { SportidentCardNumber1 = sportidentCardnumber });
            }

            foreach (var team in Presenter.Model.Teams.Where(x => x.SportidentCardNumber1 == sportidentCardnumber || x.SportidentCardNumber2 == sportidentCardnumber).ToList())
            {
                team.Laps += 1;
                team.LatestPunchTime = punchData.PunchDateTime;

                _verificationForm?.ShowPunch(team);
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
            var readerDeviceInfo = (DeviceInfo)(comboBox_sportidentDevices.SelectedItem);
            _deviceService.Connect(readerDeviceInfo);

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
            var readerDeviceInfo = (DeviceInfo)comboBox_sportidentDevices.SelectedItem;
            _deviceService.Disconnect(readerDeviceInfo);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (_verificationForm == null)
            {
                _verificationForm = new VerificationFormView();
                _verificationForm.Closed += (o, args) => _verificationForm = null;
                _verificationForm.Show(this);
            }
        }

        private void button_sportidentRefresh_Click(object sender, EventArgs e)
        {
            GetSiDevices();
        }

        public void Callback(CardPunchData card)
        {
            SavePunchData(card);
        }
    }
}