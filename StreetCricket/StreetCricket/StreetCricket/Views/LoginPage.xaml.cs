using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StreetCricket.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            ActivitySpinner.IsVisible = false;
            EntryUsername.Completed += (s, e) => EntryPassword.Focus();
            EntryPassword.Completed += (s, e) => OnSignInClicked(s, e);
            EntryUsername.Text = "Sathya";
            EntryPassword.Text = "Sathya";
        }

        private void OnSignInClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MatchList());
        }
    }
}
