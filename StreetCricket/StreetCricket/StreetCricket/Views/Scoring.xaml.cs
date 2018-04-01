using System;
using System.Linq;
using CricketLIbrary.Model;
using CricketLIbrary.Model.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StreetCricket.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Scoring : ContentPage
    {
        
        private readonly CricketMatch _cricketMatch;
        public Scoring(CricketMatch cricketMatch)
        {
            _cricketMatch = cricketMatch;
            InitializeComponent();
            
        }

        private void OnStartOverClicked(object sender, EventArgs e)
        {
            var bowler = _cricketMatch.AwayTeam.Players.FirstOrDefault();
            _cricketMatch.StartOver(_cricketMatch.CurrentInnings, new CricketPlayer(bowler)); 
        }

       

        private void OnEndOverClicked(object sender, EventArgs e)
        {
            _cricketMatch.EndOver(_cricketMatch.CurrentInnings.CurrentOver);
        }

        private void UpdateScoreBoard()
        {
            LblHomeTeamScore.Text = _cricketMatch.CurrentInnings.Overs.SelectMany(x => x.Balls).Sum(x => x.Runs.TotalRuns).ToString();
        }

        private void OnStartInningsClicked(object sender, EventArgs e)
        {
            _cricketMatch.StartInnings();
        }

        private void OnEndInningsClicked(object sender, EventArgs e)
        {
            _cricketMatch.EndInnings();
        }

        private void On0RunClicked(object sender, EventArgs e)
        {
            AddRunsOfBall(0);
        }
        private void On1RunClicked(object sender, EventArgs e)
        {
            AddRunsOfBall(1);
        }
        private void On2RunClicked(object sender, EventArgs e)
        {
            AddRunsOfBall(2);
        }

        private void On3RunClicked(object sender, EventArgs e)
        {
            AddRunsOfBall(3);
        }

        private void On4RunClicked(object sender, EventArgs e)
        {
            AddRunsOfBall(4);
        }

        private void On4PlusRunClicked(object sender, EventArgs e)
        {
            AddRunsOfBall(5);
        }

        private void On6RunClicked(object sender, EventArgs e)
        {
            AddRunsOfBall(6);
        }

        private void OnWicketRunClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnWideClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnNoBallClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnNoBallBatClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnByesClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnLegByesClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnDeadBallClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddRunsOfBall(int runsScored)
        {
            var runs = new Runs { RunsScored = runsScored };
            //_cricketMatch.AddBall(_cricketMatch.CurrentInnings.CurrentOver, BallType.Legitimate, runs,
            //    _cricketMatch.CurrentInnings.CurrentOver.Bowler, _cricketMatch.CurrentInnings.Striker);
            UpdateScoreBoard();
        }
        private void AddExtrasOfBall(int runsScored, int extrasScored, BallType ballType)
        {
            var runs = new Runs { RunsScored = runsScored, Extras = extrasScored};
            //_cricketMatch.AddBall(_cricketMatch.CurrentInnings.CurrentOver, ballType, runs,
            //    _cricketMatch.CurrentInnings.CurrentOver.Bowler, _cricketMatch.CurrentInnings.Striker);
            UpdateScoreBoard();
        }
        private void AddDismissalOfBall(int runsScored, int extrasScored, BallType ballType, CricketPlayer dismissedPlayer, CricketPlayer feilder, DisMissalType disMissalType)
        {
            var runs = new Runs { RunsScored = runsScored, Extras = extrasScored };
            _cricketMatch.AddBall(_cricketMatch.CurrentInnings.CurrentOver, ballType, runs,
                _cricketMatch.CurrentInnings.CurrentOver.Bowler, _cricketMatch.CurrentInnings.Striker, true,dismissedPlayer,feilder,disMissalType);
            UpdateScoreBoard();
        }
    }
}