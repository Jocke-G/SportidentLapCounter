namespace SportidentLapCounter
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBox_sportidentDevices = new System.Windows.Forms.ComboBox();
            this.button_sportidentConnect = new System.Windows.Forms.Button();
            this.button_sportidentDisconnect = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.columnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSportidentCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLaps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLatestPunchTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonBigger = new System.Windows.Forms.Button();
            this.buttonSmaller = new System.Windows.Forms.Button();
            this.buttonFullscreen = new System.Windows.Forms.Button();
            this.panelSettings = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_sportidentDevices
            // 
            this.comboBox_sportidentDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sportidentDevices.FormattingEnabled = true;
            this.comboBox_sportidentDevices.Location = new System.Drawing.Point(3, 3);
            this.comboBox_sportidentDevices.Name = "comboBox_sportidentDevices";
            this.comboBox_sportidentDevices.Size = new System.Drawing.Size(156, 21);
            this.comboBox_sportidentDevices.TabIndex = 4;
            // 
            // button_sportidentConnect
            // 
            this.button_sportidentConnect.Location = new System.Drawing.Point(3, 30);
            this.button_sportidentConnect.Name = "button_sportidentConnect";
            this.button_sportidentConnect.Size = new System.Drawing.Size(75, 23);
            this.button_sportidentConnect.TabIndex = 5;
            this.button_sportidentConnect.Text = "Anslut";
            this.button_sportidentConnect.UseVisualStyleBackColor = true;
            this.button_sportidentConnect.Click += new System.EventHandler(this.button_sportidentConnect_Click);
            // 
            // button_sportidentDisconnect
            // 
            this.button_sportidentDisconnect.Enabled = false;
            this.button_sportidentDisconnect.Location = new System.Drawing.Point(84, 30);
            this.button_sportidentDisconnect.Name = "button_sportidentDisconnect";
            this.button_sportidentDisconnect.Size = new System.Drawing.Size(75, 23);
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
            this.columnSportidentCardNumber,
            this.columnLaps,
            this.columnLatestPunchTime});
            this.dataGridView.Location = new System.Drawing.Point(12, 86);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(934, 464);
            this.dataGridView.TabIndex = 9;
            this.dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.SaveFile);
            this.dataGridView.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.SaveFile);
            this.dataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.SaveFile);
            // 
            // columnNumber
            // 
            this.columnNumber.DataPropertyName = "Number";
            this.columnNumber.HeaderText = "Nr";
            this.columnNumber.Name = "columnNumber";
            // 
            // columnName
            // 
            this.columnName.DataPropertyName = "Name";
            this.columnName.HeaderText = "Lagnamn";
            this.columnName.Name = "columnName";
            // 
            // columnSportidentCardNumber
            // 
            this.columnSportidentCardNumber.DataPropertyName = "SportidentCardNumber";
            this.columnSportidentCardNumber.HeaderText = "Sportident";
            this.columnSportidentCardNumber.Name = "columnSportidentCardNumber";
            // 
            // columnLaps
            // 
            this.columnLaps.DataPropertyName = "Laps";
            this.columnLaps.HeaderText = "Varv";
            this.columnLaps.Name = "columnLaps";
            // 
            // columnLatestPunchTime
            // 
            this.columnLatestPunchTime.DataPropertyName = "LatestPunchTime";
            dataGridViewCellStyle6.Format = "T";
            dataGridViewCellStyle6.NullValue = null;
            this.columnLatestPunchTime.DefaultCellStyle = dataGridViewCellStyle6;
            this.columnLatestPunchTime.HeaderText = "Senaste tid";
            this.columnLatestPunchTime.Name = "columnLatestPunchTime";
            // 
            // buttonBigger
            // 
            this.buttonBigger.Location = new System.Drawing.Point(165, 3);
            this.buttonBigger.Name = "buttonBigger";
            this.buttonBigger.Size = new System.Drawing.Size(128, 23);
            this.buttonBigger.TabIndex = 10;
            this.buttonBigger.Text = "Större [CTRL] + [+]";
            this.buttonBigger.UseVisualStyleBackColor = true;
            this.buttonBigger.Click += new System.EventHandler(this.buttonBigger_Click);
            // 
            // buttonSmaller
            // 
            this.buttonSmaller.Location = new System.Drawing.Point(165, 30);
            this.buttonSmaller.Name = "buttonSmaller";
            this.buttonSmaller.Size = new System.Drawing.Size(128, 23);
            this.buttonSmaller.TabIndex = 11;
            this.buttonSmaller.Text = "Mindre [CTRL] + [-]";
            this.buttonSmaller.UseVisualStyleBackColor = true;
            this.buttonSmaller.Click += new System.EventHandler(this.buttonSmaller_Click);
            // 
            // buttonFullscreen
            // 
            this.buttonFullscreen.Location = new System.Drawing.Point(299, 3);
            this.buttonFullscreen.Name = "buttonFullscreen";
            this.buttonFullscreen.Size = new System.Drawing.Size(128, 23);
            this.buttonFullscreen.TabIndex = 12;
            this.buttonFullscreen.Text = "Fullskärm [F11]";
            this.buttonFullscreen.UseVisualStyleBackColor = true;
            this.buttonFullscreen.Click += new System.EventHandler(this.buttonFullscreen_Click);
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSettings.Controls.Add(this.comboBox_sportidentDevices);
            this.panelSettings.Controls.Add(this.buttonFullscreen);
            this.panelSettings.Controls.Add(this.button_sportidentConnect);
            this.panelSettings.Controls.Add(this.buttonBigger);
            this.panelSettings.Controls.Add(this.buttonSmaller);
            this.panelSettings.Controls.Add(this.button_sportidentDisconnect);
            this.panelSettings.Location = new System.Drawing.Point(12, 12);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(934, 68);
            this.panelSettings.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 562);
            this.Controls.Add(this.panelSettings);
            this.Controls.Add(this.dataGridView);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Sportident Lap Counter";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_sportidentDevices;
        private System.Windows.Forms.Button button_sportidentConnect;
        private System.Windows.Forms.Button button_sportidentDisconnect;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSportidentCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLaps;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLatestPunchTime;
        private System.Windows.Forms.Button buttonBigger;
        private System.Windows.Forms.Button buttonSmaller;
        private System.Windows.Forms.Button buttonFullscreen;
        private System.Windows.Forms.Panel panelSettings;
    }
}

