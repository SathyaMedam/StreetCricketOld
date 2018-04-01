using System.Collections.Generic;

namespace CricketLIbrary.Model
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Venue Venue { get; set; }
        public int TeamInningsNumber { get; set; }
        public List<Player> Players { get; set; }

    }
    public enum Venue
    {
        Home = 1,
        Away = 2,
        
    }
}
