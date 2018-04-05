using System;
using CricketLIbrary.Model.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StreetCricket.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoringMasterPage : MasterDetailPage
    {
        private CricketMatch cricketMatch;

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
            Detail=new NavigationPage(new CoinTossPage(this.cricketMatch));
            IsPresented = false;
        }

        private void OnStartInningsClicked(object sender, EventArgs e)
        {
            cricketMatch.StartInnings();
            IsPresented = false;
        }

        private void OnEndInningsClicked(object sender, EventArgs e)
        {
            cricketMatch.EndInnings();
            IsPresented = false;
        }

        private void OnScoringClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Scoring(this.cricketMatch));
            IsPresented = false;
        }

        private void OnSelectPlayersClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new MultiSelectHomePlayersPage(this.cricketMatch));
            IsPresented = false;
        }
    }
}