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

        async void auth (string login, string password)
        {
            if(login == "admin" && password == "admin")
            {
                autt.Text = "It's alright!!!";
            }
            else
            {
                autt.Text = "LOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOSER";
                await Task.Delay(5000);
                MainPage rootPage = Application.Current.MainPage as MainPage;
                rootPage.Detail = new NavigationPage(new View1() );
                await Navigation.PushModalAsync(new NavigationPage(new View1()));
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            auth(l.Text, p.Text);
        }
    }
}