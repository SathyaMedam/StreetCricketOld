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
        private CricketMatch cricketMatch;

        public CoinTossPage ()
		{
			InitializeComponent ();
		}

        public CoinTossPage(CricketMatch cricketMatch)
        {
            InitializeComponent();
            this.cricketMatch = cricketMatch;
        }

        private void SwitchTossTeam_OnToggled(object sender, ToggledEventArgs e)
	    {
	        if (e.Value)
	        {
	            LabelSwitchTossTeam.Text = cricketMatch.HomeTeam.Name;
	            cricketMatch.Toss.TeamWonToss = cricketMatch.HomeTeam;

	        }
	        else
	        {
	            LabelSwitchTossTeam.Text = cricketMatch.AwayTeam.Name;
	            cricketMatch.Toss.TeamWonToss = cricketMatch.AwayTeam;
            }
        }

	    private void SwitchTossDecision_OnToggled(object sender, ToggledEventArgs e)
	    {
	        if (e.Value)
	        {
	            LabelSwitchTossTeam.Text = "Bat First";
	            cricketMatch.Toss.TossDecisionType = TossDecisionType.Batting;

            }
	        else
	        {
	            LabelSwitchTossTeam.Text = "Bowl First";
	            cricketMatch.Toss.TossDecisionType = TossDecisionType.Bowling;
	        }
        }

	    private void OnTossSubmitClicked(object sender, EventArgs e)
	    {
	        cricketMatch.CoinToss();
	        Navigation.PushModalAsync(new ScoringMasterPage(cricketMatch));
        }
	}
}