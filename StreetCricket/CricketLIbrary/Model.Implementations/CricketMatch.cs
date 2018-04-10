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
                    var player = this.Match.AwayPlayers.FirstOrDefault(x => x.Id == selectdPlayerId);
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

        public void StartOver(Innings currentInnings, int bowlerId)
        {
            var player = this.CurrentInnings.BowlingTeam.Players.FirstOrDefault(x => x.Id == bowlerId);
            var over = new Over
            {
                OverStauts = OverStatus.OverInProgress,
                Bowler = player,
                Number = this.CurrentInnings.Overs.Count + 1
            };
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
                ball.IsFinished = true;
            }
            if (ball.BallType == BallType.Wide)
            {
                ball.Extras = this.CricketMatchProperties.WideValue + runs;
                ball.BallAttemptNumber = ball.BallAttemptNumber + 1;
                ball.BallNumber = currentOver.Balls.Count(x => x.IsFinished);

            }
            if (ball.BallType == BallType.NoBall)
            {
                if (ball.RunsType == RunsType.Run)
                {
                    ball.Extras = this.CricketMatchProperties.NoBallValue;
                    ball.Runs = runs;
                }
                else
                {
                    ball.Extras = this.CricketMatchProperties.NoBallValue + runs;
                }
                ball.BallAttemptNumber = ball.BallAttemptNumber + 1;
                ball.BallNumber = currentOver.Balls.Count(x => x.IsFinished);
            }

            if (dismissedPlayer!=null)
            {
                 dismissedPlayer.Dismissed = isDismissal;
            }
           
            currentOver.Balls.Add(ball);
            currentOver.CurrentBall = ball;
          

            var striker = this.CurrentInnings.Striker;
            var nonStriker = this.CurrentInnings.NonStriker;
            if (IsOdd(ball.Runs))
            {
                this.CurrentInnings.Striker = nonStriker;
                this.CurrentInnings.NonStriker = striker;
            }
            if (isDismissal)
            {
                if (dismissedPlayer.Id==striker.Id)
                {
                     CurrentInnings.Striker = null;
                }
                else
                {
                    CurrentInnings.NonStriker = null;
                }
               
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

        public void SetBatsmenComingOn(int selectdPlayerId)
        {
            var player = this.CurrentInnings.BattingTeam.Players.FirstOrDefault(x => x.Id == selectdPlayerId);
            if (this.CurrentInnings.Striker == null)
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
                var ballsInInnings = innings.Overs.SelectMany(x => x.Balls).ToList();
                var runs = ballsInInnings.Sum(x => x.Runs);
                var wickets = ballsInInnings.Count(x => x.IsDismissal);
                var wides = ballsInInnings.Count(x => x.BallType == BallType.Wide);
                var wideRuns = ballsInInnings.Where(x => x.BallType == BallType.Wide).Sum(c => c.Extras);
                var noBalls = ballsInInnings.Count(x => x.BallType == BallType.NoBall);
                var noBallRuns = ballsInInnings.Where(x => x.BallType == BallType.NoBall).Sum(c => c.Extras);
                var byes = ballsInInnings.Where(x => x.RunsType == RunsType.Byes).Sum(y => y.Runs);
                var legByes = ballsInInnings.Where(x => x.RunsType == RunsType.LegByes).Sum(y => y.Runs);
                var balls = 0;
                if (innings.Overs.LastOrDefault()?.Balls != null)
                {
                    balls = Enumerable.LastOrDefault(innings.Overs).Balls.Count(x => x.IsFinished);

                }
                var overs = innings.Overs.Count() - 1 + "." + balls;
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

        public BattingScoreCard GetBattingScoreCard(bool isHomeTeam, int teamInningsNumber, int playerId)
        {
            var innings = GetInningsOfATeam(isHomeTeam, teamInningsNumber);

            if (innings != null)
            {
                var ballsFacedInInnings = innings.Overs.SelectMany(x => x.Balls).Where(x => x.Batsmen.Id == playerId).ToList();

                var runs = ballsFacedInInnings.Sum(x => x.Runs);
                var ballsFaced = ballsFacedInInnings.Count();
                var fours = ballsFacedInInnings.Count(x => x.BoundaryType == BoundaryType.Four);
                var sixers = ballsFacedInInnings.Count(x => x.BoundaryType == BoundaryType.Six);
                var dots = ballsFacedInInnings.Count(x => x.Runs == 0);
                var teamInningsScoreCard = new BattingScoreCard
                {
                    Runs = runs,
                    BallsFaced = ballsFaced,
                    NumberOfFours = fours,
                    NumberOfSixers = sixers,
                    NumberOfDotBalls = dots
                };
                return teamInningsScoreCard;
            }
            return new BattingScoreCard();
        }

        public Innings GetInningsOfATeam(bool isHomeTeam, int teamInningsNumber)
        {
            return isHomeTeam ? this.Innings.FirstOrDefault(x => x.BattingTeam.Id == this.HomeTeam.Id && x.BattingTeam.TeamInningsNumber == teamInningsNumber) : this.Innings.FirstOrDefault(x => x.BattingTeam.Id == this.AwayTeam.Id && x.BattingTeam.TeamInningsNumber == teamInningsNumber);
        }
    }
}
