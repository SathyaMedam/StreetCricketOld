using System;
using CricketLIbrary.Model.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StreetCricket.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoringMasterPage : MasterDetailPage
    {
        private readonly CricketMatch cricketMatch;

        public ScoringMasterPage()
        {
            InitializeComponent();
        }

        public ScoringMasterPage(CricketMatch cricketMatch)
        {
            InitializeComponent();
            this.cricketMatch = cricketMatch;
        }
        private void OnCoinTossClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CoinTossPage(this.cricketMatch));
            IsPresented = false;
        }

        private void OnStartInningsClicked(object sender, EventArgs e)
        {
            cricketMatch.StartInnings();
            Detail = new NavigationPage(new SelectStrikerAndNonStrikerPage(this.cricketMatch, true));
            IsPresented = false;
        }
        private void OnEndInningsClicked(object sender, EventArgs e)
        {
            cricketMatch.EndInnings();
            IsPresented = false;
        }
        private void OnSelectPlayersClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new MultiSelectHomePlayersPage(this.cricketMatch));
            IsPresented = false;
        }

        private void OnMainScoringClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Scoring(this.cricketMatch, true));
            IsPresented = false;

        }

        private void OnSelectBatsmenClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new SelectBatsmenPage(this.cricketMatch));
            IsPresented = false;
        }
    }
}