namespace CricketLIbrary.Model
{
    public class Runs
    {
        public int RunsScored { get; set; }
        public int Extras { get; set; }
        public int Fours { get; set; }
        public int Sixers { get; set; }
        public int TotalRuns
        {
            get
            {
                return RunsScored + Extras + Fours + Sixers;
            }
        }
    }

}
