using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace CricketLIbrary.Model.Implementations
{
    public class CricketMatch : ICricketMatch, IInnings
    {
        public List<Innings> Innings { get; set; }
        public Innings CurrentInnings { get; set; }
        public CricketTeam HomeTeam { get; set; }
        public CricketTeam AwayTeam { get; set; }
        public Toss Toss { get; set; }
        public Match Match { get; set; }
        public bool EnforcedFollowOn { get; set; }
        public CricketMatchProperties CricketMatchProperties { get; set; }

        public CricketMatch(Match match)
        {
            Match = match;
            Innings = new List<Innings>();
            Toss = new Toss { TeamWonToss = match.HomeTeam, TossDecisionType = TossDecisionType.Batting };
            HomeTeam = new CricketTeam(match.HomeTeam);
            AwayTeam = new CricketTeam(match.AwayTeam);
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
            var innings = new Innings
            {
                InningsNumber = this.Innings.Count() + 1,
                InningsStatus = InningsStatus.InProgress
            };
            switch (innings.InningsNumber)
            {
                case 1:
                    if (this.Toss.TeamWonToss == HomeTeam)
                    {
                        innings.BattingTeam = this.Toss.TossDecisionType == TossDecisionType.Batting ? HomeTeam : AwayTeam;
                        innings.BowlingTeam = this.Toss.TossDecisionType == TossDecisionType.Batting ? AwayTeam : HomeTeam;
                    }
                    else
                    {
                        innings.BattingTeam = this.Toss.TossDecisionType == TossDecisionType.Batting ? AwayTeam : HomeTeam;
                        innings.BowlingTeam = this.Toss.TossDecisionType == TossDecisionType.Batting ? HomeTeam : AwayTeam;
                    }

                    break;
                case 2:
                    var finishedInnings = this.Innings.FirstOrDefault(x => x.InningsNumber == 1);
                    if (finishedInnings != null && finishedInnings.BattingTeam == HomeTeam)
                    {
                        innings.BattingTeam = AwayTeam;
                        innings.BowlingTeam = HomeTeam;
                    }
                    else
                    {
                        innings.BattingTeam = HomeTeam;
                        innings.BowlingTeam = AwayTeam;
                    }

                    break;
            }

            if (this.EnforcedFollowOn)
            {
                switch (innings.InningsNumber)
                {
                    case 3:
                        {
                            var finishedInnings = this.Innings.FirstOrDefault(x => x.InningsNumber == 1);
                            if (finishedInnings != null && finishedInnings.BattingTeam == HomeTeam)
                            {
                                innings.BattingTeam = HomeTeam;
                                innings.BowlingTeam = AwayTeam;
                            }
                            else
                            {
                                innings.BattingTeam = AwayTeam;
                                innings.BowlingTeam = HomeTeam;
                            }

                            break;
                        }
                    case 4:
                        {
                            var finishedInnings = this.Innings.FirstOrDefault(x => x.InningsNumber == 2);
                            if (finishedInnings != null && finishedInnings.BattingTeam == HomeTeam)
                            {
                                innings.BattingTeam = HomeTeam;
                                innings.BowlingTeam = AwayTeam;
                            }
                            else
                            {
                                innings.BattingTeam = AwayTeam;
                                innings.BowlingTeam = HomeTeam;
                            }

                            break;
                        }
                }
            }
            else
            {
                switch (innings.InningsNumber)
                {
                    case 3:
                        {
                            var finishedInnings = this.Innings.FirstOrDefault(x => x.InningsNumber == 1);
                            if (finishedInnings != null && finishedInnings.BattingTeam == HomeTeam)
                            {
                                innings.BattingTeam = HomeTeam;
                                innings.BowlingTeam = AwayTeam;
                            }
                            else
                            {
                                innings.BattingTeam = AwayTeam;
                                innings.BowlingTeam = HomeTeam;
                            }

                            break;
                        }
                    case 4:
                        {
                            var finishedInnings = this.Innings.FirstOrDefault(x => x.InningsNumber == 2);
                            if (finishedInnings != null && finishedInnings.BattingTeam == HomeTeam)
                            {
                                innings.BattingTeam = HomeTeam;
                                innings.BowlingTeam = AwayTeam;
                            }
                            else
                            {
                                innings.BattingTeam = AwayTeam;
                                innings.BowlingTeam = HomeTeam;
                            }

                            break;
                        }
                }
            }

            innings.BattingTeam.TeamInningsNumber += 1;
            this.CurrentInnings = innings;
            this.Innings.Add(innings);
        }

        public void AddBall(Over currentOver, BallType ballType, RunsType runsType, BoundaryType boundaryType, int runs,
            CricketPlayer bowler, CricketPlayer batsmen, bool isDismissal, CricketPlayer dismissedPlayer, CricketPlayer feilder, DisMissalType disMissalType)
        {
            var ball = new Ball
            {
                BallAttemptStatus = BallAttemptStatus.InProgress,
                BallType = ballType,
                RunsType = runsType,
                Runs = runs,
                Batsmen = batsmen,
                Bowler = bowler,
                Fielder = feilder,
                IsDismissal = isDismissal,
                DisMissalType = disMissalType,
            };
            if (ball.BallType == BallType.Legitimate)
            {
                ball.BallNumber = currentOver.Balls.Count(x => x.IsFinished) + 1;
                ball.BallAttemptNumber = 1;
                batsmen.RunsScored += runs;
                ball.IsFinished = true;
                if (isDismissal)
                {
                    dismissedPlayer.Dismissed = true;
                    CurrentInnings.Striker = null;
                }

            }
            if (ball.BallType == BallType.Wide)
            {
                ball.Extras = this.CricketMatchProperties.WideValue;
                ball.BallAttemptNumber = ball.BallAttemptNumber + 1;
                ball.BallNumber = currentOver.Balls.Count(x => x.IsFinished);

            }
            if (ball.BallType == BallType.NoBall)
            {
                ball.Extras = this.CricketMatchProperties.NoBallValue;
                ball.BallAttemptNumber = ball.BallAttemptNumber + 1;
                ball.BallNumber = currentOver.Balls.Count(x => x.IsFinished);
            }

            currentOver.Balls.Add(ball);
            currentOver.CurrentBall = ball;
            if (IsOdd(ball.Runs))
            {
                this.CurrentInnings.Striker = this.CurrentInnings.NonStriker;
                this.CurrentInnings.NonStriker = this.CurrentInnings.Striker;
            }
        }
        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
        public void SetStrikerNonStrikerBatsmen(int selectdPlayerId, bool isStriker)
        {
            var player = this.CurrentInnings.BattingTeam.Players.FirstOrDefault(x => x.Id == selectdPlayerId);
            if (isStriker)
            {
                this.CurrentInnings.Striker = player;
            }
            else
            {
                this.CurrentInnings.NonStriker = player;
            }

        }

        public TeamInningsScoreCard GetTeamInningsScoreCard(bool isHomeTeam, int teamInningsNumber)
        {
            var innings = GetInningsOfATeam(isHomeTeam, teamInningsNumber);

            if (innings != null)
            {
                var runs = innings.Overs.SelectMany(x => x.Balls).Sum(x => x.Runs + x.Extras);
                var wickets = innings.Overs.SelectMany(x => x.Balls).Count(x => x.IsDismissal);
                var wides = innings.Overs.SelectMany(x => x.Balls).Count(x => x.BallType == BallType.Wide);
                var wideRuns = innings.Overs.SelectMany(x => x.Balls).Where(x => x.BallType == BallType.Wide).Sum(c => c.Runs + c.Extras);
                var noBalls = innings.Overs.SelectMany(x => x.Balls).Count(x => x.BallType == BallType.NoBall);
                var noBallRuns = innings.Overs.SelectMany(x => x.Balls).Where(x => x.BallType == BallType.NoBall).Sum(c => c.Runs + c.Extras);
                var byes = innings.Overs.SelectMany(x => x.Balls).Where(x => x.RunsType == RunsType.Byes).Sum(y => y.Runs);
                var legByes = innings.Overs.SelectMany(x => x.Balls).Where(x => x.RunsType == RunsType.LegByes).Sum(y => y.Runs);
                var overs = innings.Overs.Count()-1 + "." + Enumerable.LastOrDefault(innings.Overs).Balls.Count();
                var teamInningsScoreCard = new TeamInningsScoreCard
                {
                    Runs = runs,
                    Wickets = wickets,
                    Wides = wides,
                    WideRuns = wideRuns,
                    NoBalls = noBalls,
                    NoBallRuns = noBallRuns,
                    Byes = byes,
                    Legbyes = legByes,
                    Overs = overs
                };
                return teamInningsScoreCard;
            }
            return new TeamInningsScoreCard();
        }


        public Innings GetInningsOfATeam(bool isHomeTeam, int teamInningsNumber)
        {
            return isHomeTeam ? this.Innings.FirstOrDefault(x => x.BattingTeam.Id == this.HomeTeam.Id && x.BattingTeam.TeamInningsNumber == teamInningsNumber) : this.Innings.FirstOrDefault(x => x.BattingTeam.Id == this.AwayTeam.Id && x.BattingTeam.TeamInningsNumber == teamInningsNumber);
        }
    }
}
