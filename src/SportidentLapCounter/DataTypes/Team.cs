using System;

namespace SportidentLapCounter.DataTypes
{
    public class Team
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string SportidentCardNumber { get; set; }
        public int Laps { get; set; }
        public DateTime LatestPunchTime { get; set; }

        public Team()
        {
            LatestPunchTime = new DateTime();
        }
    }
}
