using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StreetCricket.Data;
using StreetCricket.Views;
using Xamarin.Forms;

namespace StreetCricket
{
	public partial class App : Application
	{
	    private static UserDatabaseController userDatabase;
        public App ()
		{
			InitializeComponent();

			MainPage = new LoginPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	    public static UserDatabaseController UserDatabase
	    {
	        get
	        {
	            if (userDatabase == null)
	            {
	                userDatabase = new UserDatabaseController();
	            }

	            return userDatabase;
	        }
	    }
    }
}
