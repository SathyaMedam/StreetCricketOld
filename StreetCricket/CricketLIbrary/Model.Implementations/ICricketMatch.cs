using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketLIbrary.Model.Implementations
{
    public interface ICricketMatch
    {
        CricketMatch GetMatch(Match match);
        void CoinToss();
        void StartOver(Innings currentInnings, CricketPlayer bowler);
        void EndOver(Over currentOver);
        void AddBall(Over currentOver, BallType ballType, Runs runs, CricketPlayer bowler, CricketPlayer batsmen,
            bool isDismissal, CricketPlayer dismissedPlayer, CricketPlayer feilder, DisMissalType disMissalType);
        void EndInnings();
        void StartInnings();
    }
}
