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
            this.cricketMatch = cricketMatch;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
            IsPresented = false;

          //  MasterPage.ListView.SelectedItem = null;
        }
    }
}