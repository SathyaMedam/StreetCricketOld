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
    public partial class SelectBatsmenPage : ContentPage
    {
        private readonly CricketMatch _cricketMatch;
       

        public List<SelectableData<SelectPlayerData>> DataList { get; set; }

        public SelectBatsmenPage()
        {
            InitializeComponent();
        }

        public SelectBatsmenPage(CricketMatch cricketMatch)
        {
            InitializeComponent();
            this._cricketMatch = cricketMatch;
            var playersList = new List<SelectableData<SelectPlayerData>>();
            foreach (var data in cricketMatch.CurrentInnings.BattingTeam.Players.Where(x=>!x.Dismissed))
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
        }

        private void OnFinishedClicked(object sender, EventArgs e)
        {
            var selectedPlayerId = DataList.Where(x => x.Selected).ToList().FirstOrDefault().Data.Id;

            _cricketMatch.SetBatsmenComingOn(selectedPlayerId);

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