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
		public Page1 ()
		{
			InitializeComponent ();
            foo();
		}
        async void foo()
        {
            int n = 100;
            for (int i = 0; i < n; i++)
            {
                im.Opacity = i * 1.0 / n;
                await Task.Delay(1);
            }
            await Task.Delay(n*2);
            for (int i = 0; i < n; i++)
            {
                im.Opacity = 1 - (i * 1.0 / n);
                await Task.Delay(1);
            }
            Application.Current.MainPage = new MainPage();
        }
	}
}