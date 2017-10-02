using SPORTident;
using System;
using System.Windows.Forms;

namespace SportidentLapCounter.Controls.CardInjectorForm
{
    public partial class CardInjectFormView : Form
    {
        public CardInjectFormView()
        {
            InitializeComponent();
            textBox_Time.Text = DateTime.Now.ToString();
        }

        public Action<CardPunchData> CallbackMethod { get; internal set; }

        private void button1_Click(object sender, EventArgs e)
        {
            var card = new CardPunchData
            {
                Siid = textBox_Sportident.Text,
                PunchDateTime = DateTime.Parse(textBox_Time.Text)
            };

            CallbackMethod.Invoke(card);
        }
    }
}
