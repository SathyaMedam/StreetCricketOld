using System;
using System.Collections.Generic;
using System.Linq;
using CricketLIbrary.Model.Implementations;
using StreetCricket.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StreetCricket.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectStrikerAndNonStrikerPage : ContentPage
    {
        private readonly CricketMatch _cricketMatch;
        private readonly bool _isStrikerPage;

        public List<SelectableData<SelectPlayerData>> DataList { get; set; }

        public SelectStrikerAndNonStrikerPage()
        {
            InitializeComponent();
        }

        public SelectStrikerAndNonStrikerPage(CricketMatch cricketMatch, bool isStrikerPage)
        {
            InitializeComponent();
            this._cricketMatch = cricketMatch;
            this._isStrikerPage = isStrikerPage;
            var playersList = new List<SelectableData<SelectPlayerData>>();
            foreach (var data in cricketMatch.CurrentInnings.BattingTeam.Players)
            {
                var strikerId = cricketMatch.CurrentInnings.Striker?.Id ?? 0;
                var nonStrikerId = cricketMatch.CurrentInnings.NonStriker?.Id ?? 0;
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
            LblStrikerNonStrikerText.Text = isStrikerPage ? "STRIKER" : "NON STRIKER";
        }

        private void OnFinishedClicked(object sender, EventArgs e)
        {
            var selectedPlayerId = DataList.Where(x => x.Selected).ToList().FirstOrDefault().Data.Id;
            _cricketMatch.SetStrikerNonStrikerBatsmen(selectedPlayerId, _isStrikerPage);
            Navigation.PushModalAsync(new SelectStrikerAndNonStrikerPage(_cricketMatch, false));
            if (!_isStrikerPage)
            {
                Navigation.PushModalAsync(new ScoringMasterPage(_cricketMatch));
            }
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
    }
}