using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketLIbrary.Model.Implementations
{
    public interface IInnings
    {
        void StartOver(Innings currentInnings, CricketPlayer bowler);
        void EndOver(Over currentOver);
        void AddBall(Over currentOver, BallType ballType, RunsType runsType, BoundaryType boundaryType, int runs, CricketPlayer bowler, CricketPlayer batsmen,
            bool isDismissal, CricketPlayer dismissedPlayer, CricketPlayer feilder, DisMissalType disMissalType);
        void SetStrikerNonStrikerBatsmen(int batsmenId, bool isStriker);
        TeamInningsScoreCard GetTeamInningsScoreCard(bool isHomeTeam,  int teamInningsNumber);
    }
}
