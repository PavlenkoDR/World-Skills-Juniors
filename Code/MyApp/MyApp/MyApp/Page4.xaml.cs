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
	public partial class Page4 : ContentPage
	{
		public Page4 ()
		{
			InitializeComponent ();
		}


        private bool CheckValidatiions()
        {
            if (string.IsNullOrEmpty(entryLogin.Text))
            {
                DisplayAlert("Внимание", "Введите почту", "ОК");
                return false;
            }
            if (string.IsNullOrEmpty(entryPassword.Text))
            {

                DisplayAlert("Внимание", "Введите пароль", "ОК");
                return false;
            }
            if (string.IsNullOrEmpty(entryPasswordRepeat.Text))
            {

                DisplayAlert("Внимание", "Повторите пароль", "ОК");
                return false;
            }
            if (string.IsNullOrEmpty(entryName.Text))
            {

                DisplayAlert("Внимание", "Введите имя", "ОК");
                return false;
            }
            if (string.IsNullOrEmpty(entrySecondName.Text))
            {

                DisplayAlert("Внимание", "Введите фамилию", "ОК");
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
                    token = await DependencyService.Get<IFirebaseAuthenticator>().RegsiterWithEmailPassword(entryLogin.Text, 
                                                                                                            entryPassword.Text, 
                                                                                                            entryName.Text, 
                                                                                                            entrySecondName.Text);
                    autt.Text = token;
                    await Navigation.PopAsync();
                }
                catch (ArgumentException exp)
                {
                    token = exp.Message;
                }
                catch (Exception)
                {
                    token = "Another error";
                }
            }
        }
    }
}