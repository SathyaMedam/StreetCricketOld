using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketLIbrary.Model.Implementations
{
   public class CricketMatch : ICricketMatch
    {
        public List<Innings> Innings { get; set; }
        public Innings CurrentInnings { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public CricketMatch(Match match)
        {
            Innings = new List<Innings>();
            HomeTeam = match.HomeTeam;
            AwayTeam = match.AwayTeam;
        }
        public CricketMatch GetMatch(Match match)
        {
            CricketMatch cricketMatch = new CricketMatch(match);
            var innings1 = new Innings
            {
                InningsTeam = match.HomeTeam,
                Overs = new List<Over>(),
                InningsStatus = InningsStatus.InProgress,
                InningsNumber = 1,
              
            };
            var striker = match.HomeTeam.Players.FirstOrDefault(x => x.Id == 1);
            innings1.Striker= new CricketPlayer(striker);
            var nonStriker = match.HomeTeam.Players.FirstOrDefault(x => x.Id == 2);
            innings1.NonStriker = new CricketPlayer(nonStriker);
            innings1.Runs = innings1.Overs.SelectMany(x => x.Balls).Sum(y => y.Runs.RunsScored);
            var innings2 = new Innings
            {
                InningsTeam = match.AwayTeam,
                InningsStatus = InningsStatus.NotStarted,
                Overs = new List<Over>(),
                InningsNumber = 2
            };
            innings2.Runs = innings2.Overs.SelectMany(x => x.Balls).Sum(y => y.Runs.RunsScored);

            cricketMatch.Innings = new List<Innings> { innings1, innings2 };
            return cricketMatch;
        }

        public void StartOver(Innings currentInnings, CricketPlayer bowler)
        {
            var over = new Over {OverStauts = OverStatus.OverInProgress, Bowler = (CricketPlayer) bowler};
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
            var completedInnings = this.Innings.Count(x => x.InningsStatus == InningsStatus.Finished);
            this.CurrentInnings = this.Innings.FirstOrDefault(x => x.InningsNumber == completedInnings + 1);
            var currentInnings = this.CurrentInnings;
            if (currentInnings != null) currentInnings.InningsStatus = InningsStatus.InProgress;
        }

        public void AddBall(Over currentOver, BallType ballType, Runs runs, CricketPlayer bowler, CricketPlayer batsmen, bool isDismissal, CricketPlayer dismissedPlayer, CricketPlayer feilder, DisMissalType disMissalType)
        {
            var ball = new Ball { BallAttemptStatus = BallAttemptStatus.InProgress};
            if (ballType==BallType.Legitimate)
            {
                ball.BallNumber = currentOver.Balls.Count(x => x.IsFinished) + 1;
                ball.BallAttemptNumber = 1;
                ball.Runs.RunsScored = runs.RunsScored;
                batsmen.RunsScored = runs.RunsScored;
                ball.IsFinished = true;
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
