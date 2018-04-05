using System.Collections.Generic;

namespace CricketLIbrary.Model
{
   public class Innings
    {
        public int InningsNumber { get; set; }
        public Team BattingTeam { get; set; }  
        public List<Over> Overs { get; set; }
        public Over CurrentOver { get; set; }
        public int Runs { get; set; }
        public int Wickets { get; set; }
        public InningsStatus InningsStatus { get; set; }
        public CricketPlayer Striker { get; set; }
        public CricketPlayer NonStriker { get; set; }

        public Innings()
        {
            Overs=new List<Over>();
        }

    }

    public enum InningsStatus
    {
        NotStarted,
        InProgress,
        Break,
        Finished    
    }
}
