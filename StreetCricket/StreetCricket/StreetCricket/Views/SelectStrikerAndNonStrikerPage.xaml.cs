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
        public List<SelectableData<SelectPlayerData>> DataList { get; set; }

        public SelectStrikerAndNonStrikerPage()
        {
            InitializeComponent();
        }

        public SelectStrikerAndNonStrikerPage(CricketMatch cricketMatch)
        {
            InitializeComponent();
            this._cricketMatch = cricketMatch;
            var playersList = new List<SelectableData<SelectPlayerData>>();
            foreach (var data in cricketMatch.CurrentInnings.BattingTeam.Players)
                playersList.Add(new SelectableData<SelectPlayerData>
                {
                    Data = new SelectPlayerData { Id = data.Id, Name = data.Name }
                });
            DataList = playersList;
            PlayersListView.ItemsSource = DataList;
        }

        private void OnFinishedClicked(object sender, EventArgs e)
        {
            var selectedPlayers = DataList.Where(x => x.Selected).ToList();
            _cricketMatch.AddPlayersToTeam(selectedPlayers.Select(x => x.Data.Id).ToList(), false);
            Navigation.PushModalAsync(new Scoring(_cricketMatch, true));
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

            if (Convert.ToInt32(LblNumberOfSelectedPlayers.Text) == 2)
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