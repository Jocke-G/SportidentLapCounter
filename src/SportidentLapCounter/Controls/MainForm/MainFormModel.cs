using System;
using System.ComponentModel;
using SportidentLapCounter.DataTypes;

namespace SportidentLapCounter.Controls.MainForm
{
    [Serializable]
    public class MainFormModel
    {
        public MainFormModel()
        {
            Teams = new BindingList<Team>();
            FontSize = 10;
        }

        public float FontSize { get; set; }
        public BindingList<Team> Teams { get; set; }
    }
}
