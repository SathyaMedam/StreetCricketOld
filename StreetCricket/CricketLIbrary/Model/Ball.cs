
namespace CricketLIbrary.Model
{
   public class Ball
    {
        public int BallNumber { get; set; }
        public int BallAttemptNumber { get; set; }
        public RunsType RunsType { get; set; }
        public int Runs { get; set; }
        public int Extras { get; set; }
        public BoundaryType BoundaryType { get; set; }
        public BallType BallType { get; set; }
        public BallAttemptStatus BallAttemptStatus { get; set; }
        public bool IsFinished { get; set; }
        public CricketPlayer Bowler { get; set; }
        public CricketPlayer Batsmen { get; set; }
        public CricketPlayer Fielder { get; set; }
        public bool IsDismissal { get; set; }
        public DisMissalType DisMissalType { get; set; }
       
    }

    public enum BallType
    {
        Wide,
        NoBall,
        DeadBall,
        Legitimate
    }

    public enum BallAttemptStatus
    {
        NotStarted,
        InProgress,
        Finished
    }

    public enum DisMissalType
    {
        None,
        Bowled,
        Caught,
        RunOut,
        StumpOut,
        HitWicket,
        Lbw,
        HandledTheBall,
        Mankad
    }

    public enum RunsType
    {
        Wide,
        NoBall,
        Run,
        Byes,
        LegByes
    }
    public enum BoundaryType
    {
        None,
        Four,
        Six
    }
}
