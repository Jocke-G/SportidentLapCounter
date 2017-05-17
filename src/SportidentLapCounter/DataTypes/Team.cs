using System;

namespace SportidentLapCounter.DataTypes
{
    public class Team
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string SportidentCardNumber1 { get; set; }
        public string SportidentCardNumber2 { get; set; }
        public int Laps { get; set; }
        public DateTime LatestPunchTime { get; set; }

        public Team()
        {
            LatestPunchTime = new DateTime();
        }
    }
}
