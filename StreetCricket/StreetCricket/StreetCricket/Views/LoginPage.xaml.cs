using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetCricket.Model;
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
        {   ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;
            EntryUsername.Completed += (s, e) => EntryPassword.Focus();
            EntryPassword.Completed += (s, e) => OnSignInClicked(s, e);
            EntryUsername.Text = "Sathya";
            EntryPassword.Text= "Sathya";
        }

        private void OnSignInClicked(object sender, EventArgs e)
        {
            User user = new User(EntryUsername.Text, EntryPassword.Text);
            if (user.UserValidation())
            {
                //DisplayAlert("Login", "Login Success !", "Ok");
                App.UserDatabase.SaveUser(user);
                Navigation.PushModalAsync(new MatchList());
            }
            else
            {
                DisplayAlert("Login", "Login Failed !", "Ok");
            }
        }
    }
}
