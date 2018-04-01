using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketLIbrary.Model
{
    public class CricketPlayer : Player
    {
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public DateTime TimeAtCrease { get; set; }
        public int NumberOfFours { get; set; }
        public int NumberOfSixers { get; set; }
        public int OversBowled { get; set; }
        public int BallsBowled { get; set; }
        public int RunsConceded { get; set; }
        public int NumberOfDotBallsBowled { get; set; }
        public int NumberOfWidesBowled { get; set; }
        public int NumberOfNoBallsBowled { get; set; }
        public int NumberOfMaidensBowled { get; set; }
        public int NumberOfzerosBowled { get; set; }
        public int NumberOfWickets { get; set; }
        public bool Dismissed { get; set; }

        public CricketPlayer(Player player)
        {
            this.Id = player.Id;
            this.Name = player.Name;
            this.TeamId = player.TeamId;
                              
        }

    }

    public enum PlayerRole
    {
        None,
        Captain,
        WicketKeeper
    }
}
