using System;
using System.Collections.Generic;
using System.Linq;
using CricketLIbrary.Model.Implementations;
using StreetCricket.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StreetCricket
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPlayersPage : ContentPage
    {
        private CricketMatch _cricketMatch;
        public List<SelectableData<SelectPlayerData>> DataList { get; set; }

        public SelectPlayersPage()
        {
            InitializeComponent();
        }

        public SelectPlayersPage(CricketMatch cricketMatch)
        {
            InitializeComponent();
            this._cricketMatch = cricketMatch;
            var playersList = new List<SelectableData<SelectPlayerData>>();
            foreach (var data in cricketMatch.HomeTeam.Players)
                playersList.Add(new SelectableData<SelectPlayerData>
                {
                    Data = new SelectPlayerData { Id = data.Id, Name = data.Name }
                });
            DataList = playersList;
            PlayersListView.ItemsSource = DataList;
        }
       
        private void OnFinishedClicked(object sender, EventArgs e)
        {
            var sd = DataList.Where(x => x.Selected).ToList();
            var df = sd;
        }
    }
}