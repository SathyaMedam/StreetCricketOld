using System.Collections.Generic;
using System.Linq;

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

        public void CoinToss()
        {
            var firstInnings = this.Innings.FirstOrDefault();
            var secondInnings = this.Innings.LastOrDefault();
            if (this.Toss.TeamWonToss == HomeTeam)
            {
                if (this.Toss.TossDecisionType == TossDecisionType.Batting)
                {

                    if (firstInnings != null) firstInnings.InningsTeam = HomeTeam;
                    if (secondInnings != null) secondInnings.InningsTeam = AwayTeam;
                }
                else
                {
                    if (firstInnings != null) firstInnings.InningsTeam = AwayTeam;
                    if (secondInnings != null) secondInnings.InningsTeam = HomeTeam;
                }
            }
            else
            {
                if (this.Toss.TossDecisionType == TossDecisionType.Batting)
                {

                    if (firstInnings != null) firstInnings.InningsTeam = AwayTeam;
                    if (secondInnings != null) secondInnings.InningsTeam = HomeTeam;
                }
                else
                {
                    if (firstInnings != null) firstInnings.InningsTeam = HomeTeam;
                    if (secondInnings != null) secondInnings.InningsTeam = AwayTeam;
                }
            }
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
            var completedInnings = this.Innings.Count(x => x.InningsStatus == InningsStatus.Finished);
            this.CurrentInnings = this.Innings.FirstOrDefault(x => x.InningsNumber == completedInnings + 1);
            var currentInnings = this.CurrentInnings;
            if (currentInnings != null) currentInnings.InningsStatus = InningsStatus.InProgress;
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
                    CurrentInnings.Striker = new CricketPlayer(CurrentInnings.InningsTeam.Players.FirstOrDefault(x => x.Id == 3));
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
