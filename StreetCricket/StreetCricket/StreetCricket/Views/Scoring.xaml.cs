using System;
using System.Collections.Generic;
using System.Linq;
using CricketLIbrary.Model;
using CricketLIbrary.Model.Implementations;
using StreetCricket.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StreetCricket.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Scoring : ContentPage
    {
        public List<SelectableData<SelectPlayerData>> DataList { get; set; }
        private readonly CricketMatch _cricketMatch;

        public Scoring()
        {
            InitializeComponent();
        }
        public Scoring(CricketMatch cricketMatch, bool isEnabled) : this()
        {
            _cricketMatch = cricketMatch;
            InitializeComponent();
            LayoutMain.IsEnabled = isEnabled;
            LayoutWides.IsVisible = false;
        }

        private void PopulateBolwerListview()
        {
            var playersList = new List<SelectableData<SelectPlayerData>>();
            foreach (var data in _cricketMatch.CurrentInnings.BowlingTeam.Players)
            {
                var strikerId = _cricketMatch.CurrentInnings.Striker?.Id ?? 0;
                var nonStrikerId = _cricketMatch.CurrentInnings.NonStriker?.Id ?? 0;
                if (strikerId != data.Id && nonStrikerId != data.Id)
                {
                    playersList.Add(new SelectableData<SelectPlayerData>
                    {
                        Data = new SelectPlayerData { Id = data.Id, Name = data.Name }
                    });
                }

            }

            DataList = playersList;
            PlayersListView.ItemsSource = DataList;
        }



        private void OnStartOverClicked(object sender, EventArgs e)
        {
            PopulateBolwerListview();
            LayoutBowler.IsVisible = true;
        }

        private void OnEndOverClicked(object sender, EventArgs e)
        {
            _cricketMatch.EndOver(_cricketMatch.CurrentInnings.CurrentOver);
        }

        private void UpdateScoreBoard()
        {
            var homeScoredCard = _cricketMatch.GetTeamInningsScoreCard(true, 1);

            LblHomeTeamRuns.Text = homeScoredCard.TotalRuns.ToString();
            LblHomeTeamWickets.Text = homeScoredCard.Wickets.ToString();
            LblHomeTeamOvers.Text = homeScoredCard.Overs;
            var awayScoredCard = _cricketMatch.GetTeamInningsScoreCard(false, 1);
            LblAwayTeamRuns.Text = awayScoredCard.TotalRuns.ToString();
            LblAwayTeamWickets.Text = awayScoredCard.Wickets.ToString();
            LblAwayTeamOvers.Text = awayScoredCard.Overs;
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

        private void OnWicketClicked(object sender, EventArgs e)
        {
            AddDismissalOfBall(0, 0, BallType.Legitimate, _cricketMatch.CurrentInnings.Striker, _cricketMatch.CurrentInnings.CurrentOver.Bowler,
                DisMissalType.Caught);
        }

        private void OnWideClicked(object sender, EventArgs e)
        {
            LayoutWides.IsVisible = true;

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

            _cricketMatch.AddBall(_cricketMatch.CurrentInnings.CurrentOver, BallType.Legitimate, RunsType.Run, BoundaryType.None, runsScored,
                _cricketMatch.CurrentInnings.CurrentOver.Bowler, _cricketMatch.CurrentInnings.Striker, false, null, null, DisMissalType.None);
            UpdateScoreBoard();
        }
        private void AddExtrasOfBall(int runsScored, int extrasScored, BallType ballType)
        {
            //var runs = new Runs { RunsScored = runsScored, Extras = extrasScored };
            //_cricketMatch.AddBall(_cricketMatch.CurrentInnings.CurrentOver, ballType, runs,
            //    _cricketMatch.CurrentInnings.CurrentOver.Bowler, _cricketMatch.CurrentInnings.Striker, false, null, null, DisMissalType.None);

        }
        private void AddDismissalOfBall(int runsScored, int extrasScored, BallType ballType, CricketPlayer dismissedPlayer, CricketPlayer feilder, DisMissalType disMissalType)
        {
            //var runs = new Runs { RunsScored = runsScored, Extras = extrasScored };
            //_cricketMatch.AddBall(_cricketMatch.CurrentInnings.CurrentOver, ballType, runs,
            //    _cricketMatch.CurrentInnings.CurrentOver.Bowler, _cricketMatch.CurrentInnings.Striker, true, dismissedPlayer, feilder, disMissalType);
            UpdateScoreBoard();
        }
        private void OnWide0Clicked(object sender, EventArgs e)
        {
            AddExtrasOfBall(0);
        }
        private void OnWide1Clicked(object sender, EventArgs e)
        {
            AddExtrasOfBall(1);
        }
        private void OnWide2Clicked(object sender, EventArgs e)
        {
            AddExtrasOfBall(2);
        }
        private void OnWide3Clicked(object sender, EventArgs e)
        {
            AddExtrasOfBall(3);
        }
        private void OnWide4Clicked(object sender, EventArgs e)
        {
            AddExtrasOfBall(4);
        }
        private void OnWide5Clicked(object sender, EventArgs e)
        {
            AddExtrasOfBall(5);
        }
        private void OnWide6Clicked(object sender, EventArgs e)
        {
            AddExtrasOfBall(6);
        }
        private void OnWide7Clicked(object sender, EventArgs e)
        {
            AddExtrasOfBall(7);
        }

        private void AddExtrasOfBall(int runsScored)
        {
            _cricketMatch.AddBall(_cricketMatch.CurrentInnings.CurrentOver, BallType.Wide, RunsType.Wide, BoundaryType.None, runsScored,
                _cricketMatch.CurrentInnings.CurrentOver.Bowler, _cricketMatch.CurrentInnings.Striker, false, null, null, DisMissalType.None);
            UpdateScoreBoard();
            LayoutWides.IsVisible = false;
        }

        private void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                LblNumberOfSelectedPlayers.Text = (Convert.ToInt32(LblNumberOfSelectedPlayers.Text) + 1).ToString();
            }
            else
            {
                LblNumberOfSelectedPlayers.Text = (Convert.ToInt32(LblNumberOfSelectedPlayers.Text) - 1).ToString();
            }

            if (Convert.ToInt32(LblNumberOfSelectedPlayers.Text) == 1)
            {
                LblNumberOfSelectedPlayers.TextColor = Color.ForestGreen;
                ButtonFinished.IsEnabled = true;
            }
            else
            {
                LblNumberOfSelectedPlayers.TextColor = Color.IndianRed;
                ButtonFinished.IsEnabled = false;
            }
        }

        private void OnFinishedClicked(object sender, EventArgs e)
        {
            var selectedPlayerId = DataList.Where(x => x.Selected).ToList().FirstOrDefault().Data.Id;
            _cricketMatch.StartOver(_cricketMatch.CurrentInnings, selectedPlayerId);
            LayoutBowler.IsVisible = false;
        }
    }
}