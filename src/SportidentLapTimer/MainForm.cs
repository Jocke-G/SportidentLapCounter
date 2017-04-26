using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using SPORTident;
using System.Windows.Forms;
using System.Xml.Serialization;
using SPORTident.Common;

namespace SportidentLapTimer
{
    public partial class MainForm : Form
    {
        private const string XmlPath = "database.xml";

        private Reader _reader;
        private Model _model;

        public MainForm()
        {
            InitializeComponent();
            InitializeSportidentReader();

            dataGridView.AutoGenerateColumns = false;

            _model = LoadXmlFile();
            dataGridView.DataSource = _model.Teams;
            SetFontSize(_model.FontSize);
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

        private Model LoadXmlFile()
        {
            if (!File.Exists(XmlPath))
                return new Model();

            try
            {
                using (var file = new StreamReader(XmlPath))
                {
                    var serializer = new XmlSerializer(typeof(Model));
                    var obj = serializer.Deserialize(file);
                    var model = obj as Model;
                    if (model == null)
                        return new Model();

                    file.Close();
                    return model;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return new Model();
            }
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
                if (!_model.Teams.Where(x => x.SportidentCardNumber == sportidentCardnumber).ToList().Any())
                {
                    _model.Teams.Add(new Team { SportidentCardNumber = sportidentCardnumber });
                }

                foreach (var x in _model.Teams.Where(x => x.SportidentCardNumber == sportidentCardnumber).ToList())
                {
                    x.Laps += 1;
                    x.LatestPunchTime = punchData.PunchDateTime;
                }

                _model.Teams = new BindingList<Team>(_model.Teams.OrderByDescending(x => x.Laps).ThenBy(x => x.LatestPunchTime).ToList());

                dataGridView.DataSource = null;
                dataGridView.DataSource = _model.Teams;
                dataGridView.ClearSelection();

                SaveFile();
            });
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

        private void SaveFile()
        {
            using (var streamWriter = new StreamWriter(XmlPath))
            {
                var xmlSerializer = new XmlSerializer(typeof(Model));
                xmlSerializer.Serialize(streamWriter, _model);
                streamWriter.Close();
            }
        }

        private void SaveFile(object sender, DataGridViewCellEventArgs e)
        {
            if (_model == null)
                return;

            SaveFile();
        }

        private void SaveFile(object sender, DataGridViewRowEventArgs e)
        {
            SaveFile();
        }

        private void buttonBigger_Click(object sender, EventArgs e)
        {
            Bigger();
        }

        private void Bigger()
        {
            var fontSize = dataGridView.DefaultCellStyle.Font.Size + 1;
            SetFontSize(fontSize);
            SaveFile();
        }

        private void buttonSmaller_Click(object sender, EventArgs e)
        {
            Smaller();
        }

        private void Smaller()
        {
            var fontSize = dataGridView.DefaultCellStyle.Font.Size - 1;
            SetFontSize(fontSize);
            SaveFile();
        }

        private void SetFontSize(float fontSize)
        {
            var font = new Font(dataGridView.DefaultCellStyle.Font.FontFamily, fontSize);
            dataGridView.DefaultCellStyle.Font = font;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = font;
            _model.FontSize = fontSize;
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
                if (comboBox_sportidentDevices.Enabled == true)
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
