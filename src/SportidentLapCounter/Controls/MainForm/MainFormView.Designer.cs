using System;
using System.Drawing;

namespace SportidentLapCounter.Controls.MainForm
{
    partial class MainFormView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBox_sportidentDevices = new System.Windows.Forms.ComboBox();
            this.button_sportidentConnect = new System.Windows.Forms.Button();
            this.button_sportidentDisconnect = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.columnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSportidentCardNumber1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSportidentCardNumber2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLaps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLatestPunchTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonBigger = new System.Windows.Forms.Button();
            this.buttonSmaller = new System.Windows.Forms.Button();
            this.buttonFullscreen = new System.Windows.Forms.Button();
            this.groupBoxView = new System.Windows.Forms.GroupBox();
            this.buttonVerificationWindow = new System.Windows.Forms.Button();
            this.buttonPaste = new System.Windows.Forms.Button();
            this.groupBoxWebServer = new System.Windows.Forms.GroupBox();
            this.buttonWebserverStop = new System.Windows.Forms.Button();
            this.buttonWebserverStart = new System.Windows.Forms.Button();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSportident = new System.Windows.Forms.GroupBox();
            this.button_sportidentRefresh = new System.Windows.Forms.Button();
            this.panelSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxFake = new System.Windows.Forms.GroupBox();
            this.button_Fake = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBoxView.SuspendLayout();
            this.groupBoxWebServer.SuspendLayout();
            this.groupBoxSportident.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.groupBoxFake.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_sportidentDevices
            // 
            this.comboBox_sportidentDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sportidentDevices.FormattingEnabled = true;
            this.comboBox_sportidentDevices.Location = new System.Drawing.Point(8, 23);
            this.comboBox_sportidentDevices.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_sportidentDevices.Name = "comboBox_sportidentDevices";
            this.comboBox_sportidentDevices.Size = new System.Drawing.Size(157, 24);
            this.comboBox_sportidentDevices.TabIndex = 4;
            // 
            // button_sportidentConnect
            // 
            this.button_sportidentConnect.Location = new System.Drawing.Point(8, 57);
            this.button_sportidentConnect.Margin = new System.Windows.Forms.Padding(4);
            this.button_sportidentConnect.Name = "button_sportidentConnect";
            this.button_sportidentConnect.Size = new System.Drawing.Size(100, 28);
            this.button_sportidentConnect.TabIndex = 5;
            this.button_sportidentConnect.Text = "Anslut";
            this.button_sportidentConnect.UseVisualStyleBackColor = true;
            this.button_sportidentConnect.Click += new System.EventHandler(this.button_sportidentConnect_Click);
            // 
            // button_sportidentDisconnect
            // 
            this.button_sportidentDisconnect.Enabled = false;
            this.button_sportidentDisconnect.Location = new System.Drawing.Point(116, 57);
            this.button_sportidentDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.button_sportidentDisconnect.Name = "button_sportidentDisconnect";
            this.button_sportidentDisconnect.Size = new System.Drawing.Size(100, 28);
            this.button_sportidentDisconnect.TabIndex = 6;
            this.button_sportidentDisconnect.Text = "Koppla från";
            this.button_sportidentDisconnect.UseVisualStyleBackColor = true;
            this.button_sportidentDisconnect.Click += new System.EventHandler(this.button_sportidentDisconnect_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnNumber,
            this.columnName,
            this.columnSportidentCardNumber1,
            this.columnSportidentCardNumber2,
            this.columnLaps,
            this.columnLatestPunchTime});
            this.dataGridView.Location = new System.Drawing.Point(16, 124);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(1245, 553);
            this.dataGridView.TabIndex = 9;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellValueChanged);
            this.dataGridView.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.RowAddedOrDeleted);
            this.dataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.RowAddedOrDeleted);
            // 
            // columnNumber
            // 
            this.columnNumber.DataPropertyName = "Number";
            this.columnNumber.HeaderText = "Nr";
            this.columnNumber.MinimumWidth = 6;
            this.columnNumber.Name = "columnNumber";
            // 
            // columnName
            // 
            this.columnName.DataPropertyName = "Name";
            this.columnName.HeaderText = "Lagnamn";
            this.columnName.MinimumWidth = 6;
            this.columnName.Name = "columnName";
            // 
            // columnSportidentCardNumber1
            // 
            this.columnSportidentCardNumber1.DataPropertyName = "SportidentCardNumber1";
            this.columnSportidentCardNumber1.HeaderText = "Sportident 1";
            this.columnSportidentCardNumber1.MinimumWidth = 6;
            this.columnSportidentCardNumber1.Name = "columnSportidentCardNumber1";
            // 
            // columnSportidentCardNumber2
            // 
            this.columnSportidentCardNumber2.DataPropertyName = "SportidentCardNumber2";
            this.columnSportidentCardNumber2.HeaderText = "Sportident 2";
            this.columnSportidentCardNumber2.MinimumWidth = 6;
            this.columnSportidentCardNumber2.Name = "columnSportidentCardNumber2";
            // 
            // columnLaps
            // 
            this.columnLaps.DataPropertyName = "Laps";
            this.columnLaps.HeaderText = "Varv";
            this.columnLaps.MinimumWidth = 6;
            this.columnLaps.Name = "columnLaps";
            // 
            // columnLatestPunchTime
            // 
            this.columnLatestPunchTime.DataPropertyName = "LatestPunchTime";
            dataGridViewCellStyle1.Format = "T";
            dataGridViewCellStyle1.NullValue = null;
            this.columnLatestPunchTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.columnLatestPunchTime.HeaderText = "Senaste tid";
            this.columnLatestPunchTime.MinimumWidth = 6;
            this.columnLatestPunchTime.Name = "columnLatestPunchTime";
            // 
            // buttonBigger
            // 
            this.buttonBigger.Location = new System.Drawing.Point(8, 23);
            this.buttonBigger.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBigger.Name = "buttonBigger";
            this.buttonBigger.Size = new System.Drawing.Size(171, 28);
            this.buttonBigger.TabIndex = 10;
            this.buttonBigger.Text = "Större [CTRL] + [+]";
            this.buttonBigger.UseVisualStyleBackColor = true;
            this.buttonBigger.Click += new System.EventHandler(this.buttonBigger_Click);
            // 
            // buttonSmaller
            // 
            this.buttonSmaller.Location = new System.Drawing.Point(8, 59);
            this.buttonSmaller.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSmaller.Name = "buttonSmaller";
            this.buttonSmaller.Size = new System.Drawing.Size(171, 28);
            this.buttonSmaller.TabIndex = 11;
            this.buttonSmaller.Text = "Mindre [CTRL] + [-]";
            this.buttonSmaller.UseVisualStyleBackColor = true;
            this.buttonSmaller.Click += new System.EventHandler(this.buttonSmaller_Click);
            // 
            // buttonFullscreen
            // 
            this.buttonFullscreen.Location = new System.Drawing.Point(187, 23);
            this.buttonFullscreen.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFullscreen.Name = "buttonFullscreen";
            this.buttonFullscreen.Size = new System.Drawing.Size(171, 28);
            this.buttonFullscreen.TabIndex = 12;
            this.buttonFullscreen.Text = "Fullskärm [F11]";
            this.buttonFullscreen.UseVisualStyleBackColor = true;
            this.buttonFullscreen.Click += new System.EventHandler(this.buttonFullscreen_Click);
            // 
            // groupBoxView
            // 
            this.groupBoxView.Controls.Add(this.buttonVerificationWindow);
            this.groupBoxView.Controls.Add(this.buttonBigger);
            this.groupBoxView.Controls.Add(this.buttonSmaller);
            this.groupBoxView.Controls.Add(this.buttonFullscreen);
            this.groupBoxView.Controls.Add(this.buttonPaste);
            this.groupBoxView.Location = new System.Drawing.Point(363, 4);
            this.groupBoxView.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxView.Name = "groupBoxView";
            this.groupBoxView.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxView.Size = new System.Drawing.Size(563, 92);
            this.groupBoxView.TabIndex = 16;
            this.groupBoxView.TabStop = false;
            this.groupBoxView.Text = "Visning";
            // 
            // buttonVerificationWindow
            // 
            this.buttonVerificationWindow.Location = new System.Drawing.Point(365, 23);
            this.buttonVerificationWindow.Margin = new System.Windows.Forms.Padding(4);
            this.buttonVerificationWindow.Name = "buttonVerificationWindow";
            this.buttonVerificationWindow.Size = new System.Drawing.Size(171, 28);
            this.buttonVerificationWindow.TabIndex = 14;
            this.buttonVerificationWindow.Text = "Löparfönster";
            this.buttonVerificationWindow.UseVisualStyleBackColor = true;
            this.buttonVerificationWindow.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonPaste
            // 
            this.buttonPaste.Location = new System.Drawing.Point(187, 59);
            this.buttonPaste.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPaste.Name = "buttonPaste";
            this.buttonPaste.Size = new System.Drawing.Size(171, 28);
            this.buttonPaste.TabIndex = 13;
            this.buttonPaste.Text = "Klistra in";
            this.buttonPaste.UseVisualStyleBackColor = true;
            this.buttonPaste.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxWebServer
            // 
            this.groupBoxWebServer.Controls.Add(this.buttonWebserverStop);
            this.groupBoxWebServer.Controls.Add(this.buttonWebserverStart);
            this.groupBoxWebServer.Controls.Add(this.textBoxPort);
            this.groupBoxWebServer.Controls.Add(this.label1);
            this.groupBoxWebServer.Location = new System.Drawing.Point(934, 4);
            this.groupBoxWebServer.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxWebServer.Name = "groupBoxWebServer";
            this.groupBoxWebServer.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxWebServer.Size = new System.Drawing.Size(224, 92);
            this.groupBoxWebServer.TabIndex = 15;
            this.groupBoxWebServer.TabStop = false;
            this.groupBoxWebServer.Text = "Web server";
            // 
            // buttonWebserverStop
            // 
            this.buttonWebserverStop.Enabled = false;
            this.buttonWebserverStop.Location = new System.Drawing.Point(116, 59);
            this.buttonWebserverStop.Margin = new System.Windows.Forms.Padding(4);
            this.buttonWebserverStop.Name = "buttonWebserverStop";
            this.buttonWebserverStop.Size = new System.Drawing.Size(100, 28);
            this.buttonWebserverStop.TabIndex = 8;
            this.buttonWebserverStop.Text = "Stop";
            this.buttonWebserverStop.UseVisualStyleBackColor = true;
            this.buttonWebserverStop.Click += new System.EventHandler(this.buttonWebserverStop_Click);
            // 
            // buttonWebserverStart
            // 
            this.buttonWebserverStart.Location = new System.Drawing.Point(8, 59);
            this.buttonWebserverStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonWebserverStart.Name = "buttonWebserverStart";
            this.buttonWebserverStart.Size = new System.Drawing.Size(100, 28);
            this.buttonWebserverStart.TabIndex = 7;
            this.buttonWebserverStart.Text = "Start";
            this.buttonWebserverStart.UseVisualStyleBackColor = true;
            this.buttonWebserverStart.Click += new System.EventHandler(this.buttonWebserverStart_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(116, 23);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(99, 22);
            this.textBoxPort.TabIndex = 1;
            this.textBoxPort.Text = "8080";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // groupBoxSportident
            // 
            this.groupBoxSportident.Controls.Add(this.button_sportidentRefresh);
            this.groupBoxSportident.Controls.Add(this.comboBox_sportidentDevices);
            this.groupBoxSportident.Controls.Add(this.button_sportidentConnect);
            this.groupBoxSportident.Controls.Add(this.button_sportidentDisconnect);
            this.groupBoxSportident.Location = new System.Drawing.Point(4, 4);
            this.groupBoxSportident.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxSportident.Name = "groupBoxSportident";
            this.groupBoxSportident.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxSportident.Size = new System.Drawing.Size(224, 92);
            this.groupBoxSportident.TabIndex = 14;
            this.groupBoxSportident.TabStop = false;
            this.groupBoxSportident.Text = "Sportident";
            // 
            // button_sportidentRefresh
            // 
            this.button_sportidentRefresh.Font = new System.Drawing.Font("Wingdings 3", 10F, System.Drawing.FontStyle.Bold);
            this.button_sportidentRefresh.Location = new System.Drawing.Point(173, 19);
            this.button_sportidentRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.button_sportidentRefresh.Name = "button_sportidentRefresh";
            this.button_sportidentRefresh.Size = new System.Drawing.Size(43, 28);
            this.button_sportidentRefresh.TabIndex = 7;
            this.button_sportidentRefresh.Text = "Q";
            this.button_sportidentRefresh.UseVisualStyleBackColor = true;
            this.button_sportidentRefresh.Click += new System.EventHandler(this.button_sportidentRefresh_Click);
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSettings.Controls.Add(this.groupBoxSportident);
            this.panelSettings.Controls.Add(this.groupBoxFake);
            this.panelSettings.Controls.Add(this.groupBoxView);
            this.panelSettings.Controls.Add(this.groupBoxWebServer);
            this.panelSettings.Location = new System.Drawing.Point(16, 15);
            this.panelSettings.Margin = new System.Windows.Forms.Padding(4);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(1245, 102);
            this.panelSettings.TabIndex = 14;
            this.panelSettings.WrapContents = false;
            // 
            // groupBoxFake
            // 
            this.groupBoxFake.Controls.Add(this.button_Fake);
            this.groupBoxFake.Location = new System.Drawing.Point(236, 4);
            this.groupBoxFake.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxFake.Name = "groupBoxFake";
            this.groupBoxFake.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxFake.Size = new System.Drawing.Size(119, 92);
            this.groupBoxFake.TabIndex = 15;
            this.groupBoxFake.TabStop = false;
            this.groupBoxFake.Text = "Fake";
            this.groupBoxFake.Visible = false;
            // 
            // button_Fake
            // 
            this.button_Fake.Location = new System.Drawing.Point(8, 21);
            this.button_Fake.Margin = new System.Windows.Forms.Padding(4);
            this.button_Fake.Name = "button_Fake";
            this.button_Fake.Size = new System.Drawing.Size(100, 28);
            this.button_Fake.TabIndex = 5;
            this.button_Fake.Text = "Fake";
            this.button_Fake.UseVisualStyleBackColor = true;
            this.button_Fake.Click += new System.EventHandler(this.button_Fake_Click);
            // 
            // MainFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 692);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.dataGridView);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainFormView";
            this.Text = "Sportident Lap Counter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBoxView.ResumeLayout(false);
            this.groupBoxWebServer.ResumeLayout(false);
            this.groupBoxWebServer.PerformLayout();
            this.groupBoxSportident.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.groupBoxFake.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_sportidentDevices;
        private System.Windows.Forms.Button button_sportidentConnect;
        private System.Windows.Forms.Button button_sportidentDisconnect;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonBigger;
        private System.Windows.Forms.Button buttonSmaller;
        private System.Windows.Forms.Button buttonFullscreen;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSportidentCardNumber1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSportidentCardNumber2;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLaps;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLatestPunchTime;
        private System.Windows.Forms.Button buttonPaste;
        private System.Windows.Forms.GroupBox groupBoxView;
        private System.Windows.Forms.GroupBox groupBoxWebServer;
        private System.Windows.Forms.Button buttonWebserverStop;
        private System.Windows.Forms.Button buttonWebserverStart;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSportident;
        private System.Windows.Forms.FlowLayoutPanel panelSettings;
        private System.Windows.Forms.GroupBox groupBoxFake;
        private System.Windows.Forms.Button button_Fake;
        private System.Windows.Forms.Button buttonVerificationWindow;
        private System.Windows.Forms.Button button_sportidentRefresh;
    }
}

