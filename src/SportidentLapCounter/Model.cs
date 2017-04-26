using System;
using System.ComponentModel;

namespace SportidentLapCounter
{
    [Serializable]
    public class Model
    {
        public Model()
        {
            Teams = new BindingList<Team>();
            FontSize = 10;
        }

        public float FontSize { get; set; }
        public BindingList<Team> Teams { get; set; }
    }
}
