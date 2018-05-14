using System.Drawing;
using System.Windows.Forms;
using SportidentLapCounter.DataTypes;

namespace SportidentLapCounter.Controls.VerificationForm
{
    public partial class VerificationFormView : Form
    {
        public VerificationFormView()
        {
            InitializeComponent();
        }

        public void ShowPunch(Team team)
        {
            teamNumberLabel.Text = team.Number.ToString();
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

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Smaller()
        {
            var font = new Font(teamNumberLabel.Font.FontFamily, teamNumberLabel.Font.Size - 10);
            teamNumberLabel.Font = font;
        }

        private void Bigger()
        {
            var font = new Font(teamNumberLabel.Font.FontFamily, teamNumberLabel.Font.Size + 10);
            teamNumberLabel.Font = font;
        }
    }
}