using System;
using System.Collections.Generic;
using System.Globalization;
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
        public List<SelectPlayerData> PickRunsType { get; set; }
        public List<CricketPlayer> FieldingTeamPlayers { get; set; }
        public List<CricketPlayer> BattingTeamPlayers { get; set; }
        public CricketPlayer BatsmenOut { get; set; }
        public CricketPlayer Fielder { get; set; }
        public List<String> RecentOvers { get; set; }
        public RunsType SelectdRunsType { get; set; }
        private readonly CricketMatch _cricketMatch;

        public Scoring()
        {
            InitializeComponent();
            RecentOvers =new List<string>();
        }
        public Scoring(CricketMatch cricketMatch, bool isEnabled) : this()
        {
            _cricketMatch = cricketMatch;
            InitializeComponent();
            LayoutMain.IsEnabled = isEnabled;
            UpdateScoreBoard();
        }

        private void UpdateControlState()
        {
            LayoutWides.IsVisible = false;
            LblRecentOvers.IsVisible = true;
            var overStatus = _cricketMatch.CurrentInnings.CurrentOver.OverStauts;
            if (overStatus == OverStatus.OverInProgress)
            {
                LayoutScoringButtons.IsEnabled = true;
                BtnStartOver.IsEnabled = false;
                BtnEndOver.IsEnabled = true;
                LayoutBowler.IsVisible = false;
            }
            else
            {
               
                LayoutScoringButtons.IsEnabled = false;
                BtnStartOver.IsEnabled = true;
                BtnEndOver.IsEnabled = false;
            }
          

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
            UpdateScoreBoard();
        }

        private void OnEndOverClicked(object sender, EventArgs e)
        {
            _cricketMatch.EndOver(_cricketMatch.CurrentInnings.CurrentOver);
            UpdateScoreBoard();
        }

        private void UpdateScoreBoard()
        {
            LblHomeTeamName.Text = _cricketMatch.HomeTeam.Name;
            LblAwayTeamName.Text = _cricketMatch.AwayTeam.Name;
            LblRecentOvers.ItemsSource= RecentOvers;
            RecentOvers.Add(_cricketMatch.CurrentInnings.CurrentOver.Balls.Select(x=>x.Runs).LastOrDefault().ToString());
            var homeScoredCard = _cricketMatch.GetTeamInningsScoreCard(true, 1);
            LblHomeTeamRuns.Text = homeScoredCard.TotalRuns.ToString();
            LblHomeTeamWickets.Text = homeScoredCard.Wickets.ToString();
            LblHomeTeamOvers.Text = homeScoredCard.Overs;
            var awayScoredCard = _cricketMatch.GetTeamInningsScoreCard(false, 1);
            LblAwayTeamRuns.Text = awayScoredCard.TotalRuns.ToString();
            LblAwayTeamWickets.Text = awayScoredCard.Wickets.ToString();
            LblAwayTeamOvers.Text = awayScoredCard.Overs;
            if (_cricketMatch.CurrentInnings.Striker!=null)
            {
                var batsmen1ScoreCard = _cricketMatch.GetBattingScoreCard(true, 1, _cricketMatch.CurrentInnings.Striker.Id);
            LblStrikerName.Text = _cricketMatch.CurrentInnings.Striker.Name;
            LblStrikerRuns.Text = batsmen1ScoreCard.TotalRuns.ToString();
            LblStrikerBalls.Text = batsmen1ScoreCard.BallsFaced.ToString();
            LblStrikerFours.Text = batsmen1ScoreCard.NumberOfFours.ToString();
            LblStrikerSixers.Text = batsmen1ScoreCard.NumberOfSixers.ToString();
            LblStrikerZeros.Text = batsmen1ScoreCard.NumberOfDotBalls.ToString();
            LblStrikerStrikeRate.Text = batsmen1ScoreCard.StrikeRate.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
               BoxViewStriker.IsVisible=true;
            }

            if (_cricketMatch.CurrentInnings.NonStriker != null)
            {
                var batsmen2ScoreCard =_cricketMatch.GetBattingScoreCard(true, 1, _cricketMatch.CurrentInnings.NonStriker.Id);
                LblNonStrikerName.Text = _cricketMatch.CurrentInnings.NonStriker.Name;
                LblNonStrikerRuns.Text = batsmen2ScoreCard.TotalRuns.ToString();
                LblNonStrikerBalls.Text = batsmen2ScoreCard.BallsFaced.ToString();
                LblNonStrikerFours.Text = batsmen2ScoreCard.NumberOfFours.ToString();
                LblNonStrikerSixers.Text = batsmen2ScoreCard.NumberOfSixers.ToString();
                LblNonStrikerZeros.Text = batsmen2ScoreCard.NumberOfDotBalls.ToString();
                LblNonStrikerStrikeRate.Text = batsmen2ScoreCard.StrikeRate.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                BoxViewNonStriker.IsVisible = true;
            }
            UpdateControlState();
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
            LayoutWickets.IsVisible = true;
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
        private void AddDismissalOfBall(int runsScored, BallType ballType, RunsType runsType, CricketPlayer dismissedPlayer, CricketPlayer feilder, DisMissalType disMissalType)
        {
            _cricketMatch.AddBall(_cricketMatch.CurrentInnings.CurrentOver, ballType, runsType, BoundaryType.None, runsScored,
                _cricketMatch.CurrentInnings.CurrentOver.Bowler, _cricketMatch.CurrentInnings.Striker, true, dismissedPlayer, feilder, disMissalType);
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

        private void OnStartOverFinishedClicked(object sender, EventArgs e)
        {
            var selectedPlayerId = DataList.Where(x => x.Selected).ToList().FirstOrDefault().Data.Id;
            _cricketMatch.StartOver(_cricketMatch.CurrentInnings, selectedPlayerId);
            UpdateScoreBoard();
        }

        private void OnRunOutClicked(object sender, EventArgs e)
        {
            LayoutRunOut.IsVisible = true;
            var runsType = new List<SelectPlayerData>
            {
                new SelectPlayerData{Id = 1, Name ="Runs" },
                new SelectPlayerData{Id = 2, Name ="Byes" },
                new SelectPlayerData{Id = 3, Name ="LegByes" },
                new SelectPlayerData{Id = 4, Name ="Wides" } ,
                new SelectPlayerData{Id = 5, Name ="NoBall" }

            };
            var strikerId = _cricketMatch.CurrentInnings.Striker;
            var nonStrikerId = _cricketMatch.CurrentInnings.NonStriker;
            PickerBatsmenOut.ItemsSource = BattingTeamPlayers = new List<CricketPlayer> { strikerId, nonStrikerId };
            PickerRunsType.ItemsSource = PickRunsType = runsType;
            PickerFielder.ItemsSource = FieldingTeamPlayers = _cricketMatch.CurrentInnings.BowlingTeam.Players.ToList();
        }

        private void StrikerOutClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnNonStrikerOutClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SwitchSelectBatsmen_OnToggled(object sender, ToggledEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Picker_OnBatsmenChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            BatsmenOut = (CricketPlayer)picker.SelectedItem;
            if (BatsmenOut != null)
            {
                BtnRunOutConfirm.IsEnabled = true;
            }

        }

        private void Picker_FielderChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            Fielder = (CricketPlayer)picker.SelectedItem;
        }

        private void Picker_OnRunsTypeChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            RunsType runsType = RunsType.Run;
            var selectedIndex = (SelectPlayerData)picker.SelectedItem;
            if (selectedIndex.Id == 1)
            {
                runsType = RunsType.Run;
            }
            else if (selectedIndex.Id == 2)
            {
                runsType = RunsType.Byes;
            }
            else if (selectedIndex.Id == 3)
            {
                runsType = RunsType.LegByes;
            }
            else if (selectedIndex.Id == 4)
            {
                runsType = RunsType.Wide;
            }
            else if (selectedIndex.Id == 5)
            {
                runsType = RunsType.NoBall;
            }
            SelectdRunsType = runsType;
        }

        private void OnRunOutConfirmClicked(object sender, EventArgs e)
        {
            var runs = stepper.Value;
            var ballType = BallType.Legitimate;
            if (SelectdRunsType == RunsType.Wide)
            {
                ballType = BallType.Wide;
            }
            else if (SelectdRunsType == RunsType.Wide)
            {
                ballType = BallType.NoBall;
            }
            AddDismissalOfBall((int)runs, ballType, SelectdRunsType, BatsmenOut, Fielder, DisMissalType.RunOut);
            LayoutRunOut.IsVisible = false;
            LayoutWickets.IsVisible = false;
            LayoutMain.IsEnabled = false;


        }
    }
}