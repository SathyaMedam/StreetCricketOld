using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CricketLIbrary.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StreetCricket.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchList : ContentPage
    {
        public MatchList()
        {
            InitializeComponent();
            var matches = new CricketLIbrary.Data.Matches();
            MatchListView.ItemsSource = matches.MatchList;

        }

        private void OnMatchSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem!=null)
            {
                var selectedMatch = e.SelectedItem as Match;
                if (selectedMatch != null) Navigation.PushModalAsync(new MatchInfo(selectedMatch));
            }
        }
    }
}