# Урок 11 - HttpClient - тройной форсаж

Просто в коде палите на Page3.xaml.cs

## Page3.xaml

```xaml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MyApp.Page3">
    <ContentPage.Content>
        <StackLayout>
            <Entry Text="pavlenkodima1996@mail.ru" x:Name="login"></Entry>
            <Entry Text="qweqweqwe" x:Name="password"></Entry>
            <Button Text="Get" Clicked="Button_Clicked"></Button>
            <Button Text="Post" Clicked="Button_Clicked_1"></Button>
            <Button Text="Get VK" Clicked="Button_Clicked_2"></Button>
            <Button Text="Post VK" Clicked="Button_Clicked_3"></Button>
            <Label Text="Welcome to Xamarin.Forms!" x:Name="label1"
                VerticalOptions="CenterAndExpand" 
                HorizontalOptions="CenterAndExpand" />
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

## Page3.xaml.cs

```cs
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{

    // Пример JSON ответа приходящего от вк
    // {"access_token":"bb4jk5bk4j5n4hjk4n5i4uhto4tih4ohtio4hgi4","expires_in":0,"user_id":203008027}
    // Тут есть поля access_token, expires_in и user_id
    // Так и называем их в своем классе

    // Пример работы с классом в функции Button_Clicked_2

    public class VKJson
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string user_id { get; set; }
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
            // Обычный GET, который вернет загружаемую страницу, как если бы вы ее открыли в браузере и посмотрели на ее код
            // Создаем HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Url на который переходим
                    string url = "http://www.contoso.com/";

                    // GetAsync - GET запрос
                    HttpResponseMessage response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // lable1 объявлен в Page3.xaml
                    label1.Text = responseBody;
                }
                catch (HttpRequestException ex)
                {
                    // HttpResponseMessage может кинуть ошибку, обрабатываем
                    label1.Text = "Ошибка! " + ex.Message;
                }
            }
            // Тут HttpClient умер
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            // Пример авторизации на duolingo.com через POST запрос

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = "https://www.duolingo.com/2016-04-13/login?fields=";

                    // Тут собираем некоторый массив, который будем посылать
                    var data = new { identifier = login.Text, password = password.Text };

                    // Далее этот массив преобразуем в JSON. Выглядить он будет так
                    // { identifier = "login123", password = "pass123" }
                    var json = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                    // GetAsync - POST запрос
                    HttpResponseMessage response = await client.PostAsync(url, json);
                    
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    label1.Text = responseBody;
                }
                catch (HttpRequestException ex)
                {
                    label1.Text = "Ошибка! " + ex.Message;
                }
            }
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            // Пример авторизации в vk.com через GET запрос

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Да, такой ебанутый API, но для примера катит
                    string url = "https://oauth.vk.com/token?grant_type=password&client_id=3140623&client_secret=VeWdmVclDCtn6ihuP1nt&username="+login.Text+"&password="+password.Text;

                    HttpResponseMessage response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Вот тут уже JSON в формате строки преобразуем в наш ламповый класс
                    VKJson json = JsonConvert.DeserializeObject<VKJson>(responseBody);

                    label1.Text = "token: " + json.access_token + "\n"; // "\n" - перенос строки
                    label1.Text += "expires_in: " + json.expires_in + "\n";
                    label1.Text += "user_id: " + json.user_id + "\n";
                }
                catch (HttpRequestException ex)
                {
                    label1.Text = "Ошибка авторизации! " + ex.Message;
                }
                catch (Exception ex)
                {
                    // Ошиба на случай, если упадет преобразование из JSON в VKJson
                    label1.Text = "Иная ошибка! " + ex.Message;
                }
            }
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = "https://vk.com/login";

                    var data = new {
                        act = "password",
                        role = "al_frame",
                        _origin = "https://vk.com",
                        ip_h = "b110308e730703d76e",
                        lg_h = "a6f6b560600ad76403",
                        email = login.Text,
                        pass = password.Text,
                    };
                    var json = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, json);

                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    label1.Text = responseBody;
                }
                catch (HttpRequestException ex)
                {
                    label1.Text = "Ошибка! " + ex.Message;
                }
            }
        }
    }
}
```