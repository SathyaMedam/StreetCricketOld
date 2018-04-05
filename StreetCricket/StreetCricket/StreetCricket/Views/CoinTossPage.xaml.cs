using System;
using CricketLIbrary.Model;
using CricketLIbrary.Model.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StreetCricket.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoinTossPage : ContentPage
    {
        private readonly CricketMatch cricketMatch;
        private Team TeamWon;
        public TossDecisionType TossDecisionType;
        public CoinTossPage()
        {
            InitializeComponent();
        }

        public CoinTossPage(CricketMatch cricketMatch)
        {
            InitializeComponent();
            this.cricketMatch = cricketMatch;
            BindingContext = cricketMatch;
            LabelSwitchTossTeam.Text = cricketMatch.HomeTeam.Name;
            LabelSwitchTossDecision.Text = "Bat First";
        }

        private void SwitchTossTeam_OnToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                LabelSwitchTossTeam.Text = cricketMatch.AwayTeam.Name;
                TeamWon = cricketMatch.AwayTeam;
            }
            else
            {
                LabelSwitchTossTeam.Text = cricketMatch.HomeTeam.Name;
                TeamWon = cricketMatch.HomeTeam;
            }
        }

        private void SwitchTossDecision_OnToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                LabelSwitchTossDecision.Text = "Bowl First";
                TossDecisionType = TossDecisionType.Bowling;
            }
            else
            {
                LabelSwitchTossDecision.Text = "Bat First";
                TossDecisionType = TossDecisionType.Batting;
            }
        }

        private void OnTossSubmitClicked(object sender, EventArgs e)
        {
            cricketMatch.CoinToss(TeamWon, TossDecisionType);
            Navigation.PushModalAsync(new ScoringMasterPage(cricketMatch));
        }
    }
}