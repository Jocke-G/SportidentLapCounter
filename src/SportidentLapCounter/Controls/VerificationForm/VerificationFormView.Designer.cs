namespace SportidentLapCounter.Controls.VerificationForm
{
    partial class VerificationFormView
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
            this.teamNumberLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // teamNumberLabel
            // 
            this.teamNumberLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teamNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamNumberLabel.Location = new System.Drawing.Point(0, 0);
            this.teamNumberLabel.Name = "teamNumberLabel";
            this.teamNumberLabel.Size = new System.Drawing.Size(284, 262);
            this.teamNumberLabel.TabIndex = 0;
            this.teamNumberLabel.Text = "#";
            this.teamNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VerificationFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.teamNumberLabel);
            this.Name = "VerificationFormView";
            this.Text = "VerificationFormView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label teamNumberLabel;
    }
}