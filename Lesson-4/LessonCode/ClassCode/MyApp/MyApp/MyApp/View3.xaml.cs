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

        private void Button_Clicked(object sender, EventArgs e)
        {
            auth(l.Text ,p.Text);
        }
    }
}