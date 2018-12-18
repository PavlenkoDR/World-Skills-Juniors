using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
    public interface IAuth
    {
       Task<string> LogIn(string L, string P);

    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page3 : ContentPage
	{
        
		public Page3 ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            label1.Text = await DependencyService.Get<IAuth>().LogIn("gf", "gf");
        }
    }
}