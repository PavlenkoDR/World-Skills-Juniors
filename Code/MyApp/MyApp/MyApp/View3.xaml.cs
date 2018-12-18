using FirebaseAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class View3 : ContentPage
	{
		public View3 ()
		{
       
		InitializeComponent ();
		}

        void auth (string login, string password)
        {
            if(login == "admin" && password == "admin")
            {
                autt.Text = "It's alright!!!";
            }
            else
            {
                autt.Text = "LOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOSER";
            }
        }

        private bool CheckValidatiions()
        {
            if (string.IsNullOrEmpty(l.Text))
            {
                DisplayAlert("Alert", "Enter email", "ok");
                return false;
            }
            if (string.IsNullOrEmpty(p.Text))
            {

                DisplayAlert("Alert", "Enter password", "ok");
                return false;
            }
            return true;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (CheckValidatiions())
            {
                string token;
                try
                {
                    token = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailPassword(l.Text, p.Text);
                }
                catch (Exception)
                {
                    token = "LoginWithEmailPassword error";
                }
                autt.Text = token;
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (CheckValidatiions())
            {
                string token;
                try
                {
                    token = await DependencyService.Get<IFirebaseAuthenticator>().RegsiterWithEmailPassword(l.Text, p.Text);
                }
                catch (Exception)
                {
                    token = "LoginWithEmailPassword error";
                }
                autt.Text = token;
            }
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            string token;
            try
            {
                token = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailAnonymously();
            }
            catch (Exception)
            {
                token = "LoginWithEmailAnonymously error";
            }
            autt.Text = token;
        }
    }
}