using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CricketLIbrary.Data;
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
        private CricketMatch cricketMatch ;
        public MatchInfo(Match match)
        {
           
            this._match = match;
            cricketMatch = new CricketMatch(match);
            InitializeComponent();
            EntryNumberOfOvers.Text = 45.ToString();
            this.BindingContext = match;
        }

        private void OnSelectPlayersClicked(object sender, EventArgs e)
        {

        }

        private void OnCoinTossClicked(object sender, EventArgs e)
        {

        }

        private void OnStartMatchClicked(object sender, EventArgs e)
        {
            var properties = new CricketMatchProperties
            {
                NumberOfOvers = Convert.ToInt32(EntryNumberOfOvers.Text)
            };

            _match.CricketMatchProperties = properties;

            Navigation.PushModalAsync(new Scoring(cricketMatch.GetMatch(_match)));
        }
    }
}