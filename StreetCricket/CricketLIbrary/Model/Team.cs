using System.Collections.Generic;

namespace CricketLIbrary.Model
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Venue Venue { get; set; }
        public int TeamInningsNumber { get; set; }
        public List<CricketPlayer> Players { get; set; }

        public Team()
        {
                Players=new List<CricketPlayer>();
        }

    }
    
    public enum Venue
    {
        Home = 1,
        Away = 2,
        
    }
}
