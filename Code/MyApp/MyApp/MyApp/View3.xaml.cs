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

        // auth - название функции, которую мы будем вызывать
        // void - говорит о том, что функция ничего не возвращает
        // Принимает в себя два стринга
        void auth ( string login, string password )
        {
            // Если логин и пароль нужные, то выполнится первая часть кода
            // Если нет, то та, которая идет после else
            // && - логическое или
            if ( login == "admin" && password == "admin" )
            {
                // autt указан в Label в поле x:Name. Этот Label инициализирован в файле View3.xaml
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

        // Реализация функции, которая вызывается при нажатии на кнопку
        // Она привязывается в файле xaml
        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (CheckValidatiions())
            {
                string token;
                try
                {
                    token = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailPassword(l.Text, p.Text);
                }
                catch (ArgumentException exp)
                {
                    token = exp.Message;
                }
                catch (Exception)
                {
                    token = "Another error";
                }
                autt.Text = token;
                string result = "";
                IFirebaseAuthenticator user = null;
                try
                {
                    user = await DependencyService.Get<IFirebaseAuthenticator>().GetDataFromDataBase(l.Text);
                    result = "Email: < " + user.Email + " >\nName: < " + user.Name + " >\nSecond Name: < " + user.SecondName + " >";
                    // autt указан в Label в поле x:Name. Этот Label инициализирован в файле View3.xaml
                    autt.Text = result;
                    View2.user = user;
                    await Navigation.PopAsync();
                }
                catch (ArgumentException exp)
                {
                    result = exp.Message;
                }
                catch (Exception)
                {
                    result = "Another error";
                }

            }
        }

        // Реализация функции, которая вызывается при нажатии на кнопку
        // Она привязывается в файле xaml
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            string token;
            try
            {
                token = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailAnonymously();
            }
            catch (ArgumentException exp)
            {
                token = exp.Message;
            }
            catch (Exception)
            {
                token = "Another error";
            }
            // autt указан в Label в поле x:Name. Этот Label инициализирован в файле View3.xaml
            autt.Text = token;
        }
    }
}