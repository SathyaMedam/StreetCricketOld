using System;
using CricketLIbrary.Model;
using CricketLIbrary.Model.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StreetCricket.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WidePopupPage : ContentView
	{
        private CricketMatch _cricketMatch;

        public WidePopupPage()
	    {
            InitializeComponent();
	    }

        public WidePopupPage(CricketMatch cricketMatch)
        {
            InitializeComponent();
            _cricketMatch = cricketMatch;
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
	        Navigation.PushModalAsync(new Scoring(_cricketMatch,true));
        }
    }
}
