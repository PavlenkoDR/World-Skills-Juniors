using App3.Include.VKApi;
using System;
using System.IO;
using System.Net.Http;
using Xamarin.Forms;


namespace App3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.json");
            if (File.Exists(fileName))
            {
                try
                {
                    string responseBody = File.ReadAllText(fileName);

                    VKSession.Auth(responseBody);
                    OpenNews();
                }
                catch (HttpRequestException ex)
                {
                    DisplayAlert("Ошибка авторизации!", "Неверный логин или пароль!\n" + ex.Message, "OK");
                    File.Delete(fileName);
                }
                catch (Exception ex)
                {
                    // Ошиба на случай, если упадет преобразование из JSON в VKJson
                    DisplayAlert("Иная ошибка!", ex.Message, "OK");
                }
            }

        }

        public void OpenNews()
        {
            var newPage = new NavigationPage(new News());
            Navigation.PushModalAsync(newPage);
            newPage.BarBackgroundColor = Color.FromHex("#030c1c");

            //Application.Current.MainPage = new NavigationPage(new News());
            //(Application.Current.MainPage as NavigationPage).BarBackgroundColor = Color.FromHex("#030c1c");
        }

        private async void Auth_Clicked(object sender, EventArgs e)
        {
            // Пример авторизации в vk.com через GET запрос

            try
            {
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.json");

                await VKSession.Auth(login.Text, password.Text);

                File.WriteAllText(fileName, VKSession.user.Serialize());

                // Скрываем наш модный попап
                popupLoginView.IsVisible = false;

                OpenNews();
            }
            catch (HttpRequestException ex)
            {
                await DisplayAlert("Ошибка авторизации!", "Неверный логин или пароль!\n" + ex.Message, "OK");
            }
            catch (Exception ex)
            {
                // Ошиба на случай, если упадет преобразование из JSON в VKJson
                await DisplayAlert("Иная ошибка!", ex.Message, "OK");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            popupLoginView.IsVisible = true;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            popupLoginView.IsVisible = false;
        }
    }
}
