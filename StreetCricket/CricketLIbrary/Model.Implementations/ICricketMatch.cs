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
        void AddPlayersToTeam(List<int> selectdPlayerIds, bool isHomeTeam);
        void CoinToss(Team teamWon, TossDecisionType decisionType);
        void EndInnings();
        void StartInnings();
        Innings GetInningsOfATeam(bool isHomeTeam, int teamInningsNUmber);
    }
}
