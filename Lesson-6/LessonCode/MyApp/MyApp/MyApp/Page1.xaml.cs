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
	public partial class Page1 : ContentPage
	{
        async void Load( int ms )
        {
            for (int i = 0; i < ms / 4; i++)
            {
                label1.Opacity = i * 4.0 / ms;
                await Task.Delay(1);
            }
            await Task.Delay(ms / 2);
            for (int i = 0; i < ms / 4; i++)
            {
                label1.Opacity = ( ms / 4 - i ) * 4.0 / ms;
                await Task.Delay(1);
            }
            Application.Current.MainPage = new MainPage();
            
            //await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }

		public Page1 ()
		{
			InitializeComponent ();
            Load(500);
        }
	}
}