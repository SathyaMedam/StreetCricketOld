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
            _cricketMatch.StartOver(_cricketMatch.CurrentInnings, (CricketPlayer) bowler);
        }

        private void On1RunClicked(object sender, EventArgs e)
        {
            var runs =new Runs{RunsScored = 1};
            _cricketMatch.AddBall(_cricketMatch.CurrentInnings.CurrentOver, BallType.Legitimate, runs,_cricketMatch.CurrentInnings.CurrentOver.Bowler, _cricketMatch.CurrentInnings.Striker);
            UpdateScoreBoard();
        }

        private void OnEndOverClicked(object sender, EventArgs e)
        {
            _cricketMatch.EndOver(_cricketMatch.CurrentInnings.CurrentOver);
        }

        private void UpdateScoreBoard()
        {
            Runs.Text = _cricketMatch.CurrentInnings.Overs.SelectMany(x => x.Balls).Sum(x => x.Runs.TotalRuns).ToString();
        }

        private void OnStartInningsClicked(object sender, EventArgs e)
        {
            _cricketMatch.StartInnings();
        }

        private void OnEndInningsClicked(object sender, EventArgs e)
        {
            _cricketMatch.EndInnings();
        }
    }
}