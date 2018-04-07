using System.Collections.Generic;

namespace CricketLIbrary.Model
{
   public class Innings
    {
        public int InningsNumber { get; set; }
        public CricketTeam BattingTeam { get; set; }
        public CricketTeam BowlingTeam { get; set; }
        public List<Over> Overs { get; set; }
        public Over CurrentOver { get; set; }
        public int PenaltyRuns { get; set; }
        public InningsStatus InningsStatus { get; set; }
        public CricketPlayer Striker { get; set; }
        public CricketPlayer NonStriker { get; set; }

        public Innings()
        {
            Overs=new List<Over>();
            CurrentOver=new Over();
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
