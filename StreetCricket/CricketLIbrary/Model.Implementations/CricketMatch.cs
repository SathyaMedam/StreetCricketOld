using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CricketLIbrary.Model.Implementations
{
    public class CricketMatch : ICricketMatch
    {
        public List<Innings> Innings { get; set; }
        public Innings CurrentInnings { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Toss Toss { get; set; }
        public Match Match { get; set; }
        public CricketMatchProperties CricketMatchProperties { get; set; }
        public int MatchInningsNumber { get; set; }

        public CricketMatch(Match match)
        {
            Match = match;
            Innings = new List<Innings>();
            Toss = new Toss { TeamWonToss = match.HomeTeam, TossDecisionType = TossDecisionType.Batting };
            HomeTeam = match.HomeTeam;
            AwayTeam = match.AwayTeam;
        }
        public CricketMatch GetMatch(Match match)
        {
            CricketMatch cricketMatch = new CricketMatch(match) { CricketMatchProperties = match.CricketMatchProperties };
            return cricketMatch;
        }

        public void AddPlayersToTeam(List<int> selectdPlayerIds, bool isHomeTeam)
        {
            if (isHomeTeam)
            {
                foreach (var selectdPlayerId in selectdPlayerIds)
                {
                    var player = this.Match.HomePlayers.FirstOrDefault(x => x.Id == selectdPlayerId);
                    var cricketPlayer = new CricketPlayer(player);
                    this.HomeTeam.Players.Add(cricketPlayer);
                }
            }
            else
            {
                foreach (var selectdPlayerId in selectdPlayerIds)
                {
                    var player = this.Match.HomePlayers.FirstOrDefault(x => x.Id == selectdPlayerId);
                    var cricketPlayer = new CricketPlayer(player);
                    this.AwayTeam.Players.Add(cricketPlayer);
                }
            }

        }

        public void CoinToss(Team teamWon, TossDecisionType decisionType)
        {
            this.Toss.TeamWonToss = teamWon;
            this.Toss.TossDecisionType = decisionType;
        }

        public void StartOver(Innings currentInnings, CricketPlayer bowler)
        {
            var over = new Over { OverStauts = OverStatus.OverInProgress, Bowler = (CricketPlayer)bowler };
            over.Number = over.Number + 1;
            currentInnings.CurrentOver = over;
            currentInnings.Overs.Add(over);
        }

        public void EndOver(Over currentOver)
        {
            currentOver.OverStauts = OverStatus.OverFinished;
        }

        public void EndInnings()
        {
            this.CurrentInnings.InningsStatus = InningsStatus.Finished;
        }

        public void StartInnings()
        {
            this.MatchInningsNumber = MatchInningsNumber + 1;

            if (MatchInningsNumber == 1)
            {
                var innings = new Innings
                {
                    InningsNumber = 1,
                    InningsStatus = InningsStatus.InProgress
                };
                if (this.Toss.TeamWonToss == HomeTeam)
                {
                    innings.BattingTeam = this.Toss.TossDecisionType == TossDecisionType.Batting ? HomeTeam : AwayTeam;
                }
                else
                {
                    innings.BattingTeam = this.Toss.TossDecisionType == TossDecisionType.Batting ? AwayTeam : HomeTeam;
                }
                this.CurrentInnings = innings;
                this.Innings.Add(innings);

            }
            else
            {
                var finishedInnings = this.Innings.FirstOrDefault();
                var innings = new Innings
                {
                    InningsNumber = 1,
                    InningsStatus = InningsStatus.InProgress
                };
                if (finishedInnings != null && finishedInnings.BattingTeam == HomeTeam)
                {
                    innings.BattingTeam = AwayTeam;
                }
                else
                {
                    innings.BattingTeam = HomeTeam;
                }
                this.CurrentInnings = innings;
                this.Innings.Add(innings);
            }
        }

        public void AddBall(Over currentOver, BallType ballType, Runs runs, CricketPlayer bowler, CricketPlayer batsmen, bool isDismissal, CricketPlayer dismissedPlayer, CricketPlayer feilder, DisMissalType disMissalType)
        {
            var ball = new Ball { BallAttemptStatus = BallAttemptStatus.InProgress };
            if (ballType == BallType.Legitimate)
            {
                ball.BallNumber = currentOver.Balls.Count(x => x.IsFinished) + 1;
                ball.BallAttemptNumber = 1;
                ball.Runs.RunsScored = runs.RunsScored;
                batsmen.RunsScored = runs.RunsScored;
                ball.IsFinished = true;
                if (isDismissal)
                {
                    dismissedPlayer.Dismissed = true;
                    CurrentInnings.Striker = new CricketPlayer(CurrentInnings.BattingTeam.Players.FirstOrDefault(x => x.Id == 3));
                }




            }
            if (ballType == BallType.Wide)
            {
                ball.BallAttemptNumber = ball.BallAttemptNumber + 1;
                ball.BallNumber = currentOver.Balls.Count(x => x.IsFinished);
                ball.Runs.Extras = runs.Extras;
            }
            if (ballType == BallType.NoBall)
            {
                ball.BallAttemptNumber = ball.BallAttemptNumber + 1;
                ball.BallNumber = currentOver.Balls.Count(x => x.IsFinished);
                ball.Runs.Extras = runs.Extras;
            }
            if (ballType == BallType.NoBallBat)
            {
                ball.BallAttemptNumber = ball.BallAttemptNumber + 1;
                ball.BallNumber = currentOver.Balls.Count(x => x.IsFinished);
                ball.Runs.Extras = runs.Extras;
                ball.Runs.RunsScored = runs.RunsScored;
            }
            currentOver.Balls.Add(ball);
        }

    }
}
