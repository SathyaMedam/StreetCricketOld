using System.Collections.Generic;

namespace CricketLIbrary.Model
{
    public class Over
    {
        public List<Ball> Balls { get; set; }
        public int Number { get; set; }
        public OverStatus OverStauts { get; set; }
        public CricketPlayer Bowler { get; set; }
        public Ball CurrentBall { get; set; }

        public Over()
        {
            Balls=new List<Ball>();
            CurrentBall=new Ball();
        }
    }
    

    public enum OverStatus
    {
        OverNotStarted,
        OverInProgress,
        OverFinished
    }
}
