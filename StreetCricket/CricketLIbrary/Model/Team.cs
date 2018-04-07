using System.Collections.Generic;

namespace CricketLIbrary.Model
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Venue Venue { get; set; }
    }
    
    public enum Venue
    {
        Home = 1,
        Away = 2,
        
    }
}
