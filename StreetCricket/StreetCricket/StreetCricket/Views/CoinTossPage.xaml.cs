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
            BindingContext = cricketMatch;
            LabelSwitchTossTeam.Text = cricketMatch.HomeTeam.Name;
            LabelSwitchTossDecision.Text = "Bat First";
        }

        private void SwitchTossTeam_OnToggled(object sender, ToggledEventArgs e)
	    {
	        if (e.Value)
	        {
	           
 LabelSwitchTossTeam.Text = cricketMatch.AwayTeam.Name;
	            cricketMatch.Toss.TeamWonToss = cricketMatch.AwayTeam;
	        }
	        else
	        {
	            LabelSwitchTossTeam.Text = cricketMatch.HomeTeam.Name;
	            cricketMatch.Toss.TeamWonToss = cricketMatch.HomeTeam;
               
            }
        }

	    private void SwitchTossDecision_OnToggled(object sender, ToggledEventArgs e)
	    {
	        if (e.Value)
	        {
	            LabelSwitchTossDecision.Text = "Bowl First";
	            cricketMatch.Toss.TossDecisionType = TossDecisionType.Bowling;
                

            }
	        else
	        {
	            LabelSwitchTossDecision.Text = "Bat First";
	            cricketMatch.Toss.TossDecisionType = TossDecisionType.Batting;
            }
        }

	    private void OnTossSubmitClicked(object sender, EventArgs e)
	    {
	        cricketMatch.CoinToss();
	        Navigation.PushModalAsync(new ScoringMasterPage(cricketMatch));
        }
	}
}