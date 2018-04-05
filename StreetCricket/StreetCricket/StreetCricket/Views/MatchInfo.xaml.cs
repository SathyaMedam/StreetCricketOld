using System;
using CricketLIbrary.Model;
using CricketLIbrary.Model.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StreetCricket.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchInfo : ContentPage
    {
        private readonly Match _match;
        private readonly CricketMatch _cricketMatch;
        private FormatType _formatType;

        public MatchInfo()
        {
            InitializeComponent();
        }
        public MatchInfo(Match match)
        {
            this._match = match;
            _cricketMatch = new CricketMatch(match);
            InitializeComponent();
            EntryNumberOfOvers.Text = 45.ToString();
            this.BindingContext = match;
        }

        private void OnSetMatchFormatClicked(object sender, EventArgs e)
        {
            var properties = new CricketMatchProperties
            {
                NumberOfOvers = Convert.ToInt32(EntryNumberOfOvers.Text),
                WideValue = Convert.ToInt32(EntryWideBallValue.Text),
                NoBallValue = Convert.ToInt32(EntryNoBallValue.Text),
                NumberOfPlayersPerTeam = Convert.ToInt32(EntryNumberOfPlayers.Text),
                FormatType = this._formatType
            };
            _match.CricketMatchProperties = properties;
            Navigation.PushModalAsync(new ScoringMasterPage(_cricketMatch.GetMatch(_match)));
        }

        private void SwitchFormat_OnToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                LabelSwitchOutcome.Text = "Test";
                this._formatType = FormatType.TEST;
            }
            else
            {
                LabelSwitchOutcome.Text = "Limited Overs";
                this._formatType = FormatType.ODI;
            }
        }
    }
}