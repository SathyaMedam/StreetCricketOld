using System.Collections.Generic;

namespace CricketLIbrary.Model
{
    public class Match
    {
        public int MatchId { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public string MatchName { get; set; }
        public CricketMatchProperties CricketMatchProperties { get; set; }  

    }
}
