
namespace CricketLIbrary.Model
{
   public class Ball
    {
        public int BallNumber { get; set; }
        public int BallAttemptNumber { get; set; }
        public Runs Runs { get; set; }
        public BallType BallType { get; set; }
        public BallAttemptStatus BallAttemptStatus { get; set; }
        public bool IsFinished { get; set; }

        public Ball()
        {
                Runs=new Runs();
        }
    }

    public enum BallType
    {
        Wide,
        NoBall,
        NoBallBat,
        DeadBall,
        Legitimate
    }

    public enum BallAttemptStatus
    {
        NotStarted,
        InProgress,
        Finished
    }
}
