using App3.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace App3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public class VKJson
        {
            public string access_token { get; set; }
            public string expires_in { get; set; }
            public string user_id { get; set; }
        }

        public class GenericJson
        {
            public string key = "";
            public Object value = null;
        }

        private async Task ReadJson(JsonTextReader reader, GenericJson jenericJson, string deep = "" )
        {
            //label1.Text += ">>>>>>>>>>>>>>>>>>>>>>>>>\n";
            string str = "";

            if (reader.TokenType.ToString() == "None")
            {
                if (!reader.Read()) return;
            }
            switch (reader.TokenType.ToString())
            {
                case "StartObject":
                    if (jenericJson.value == null)
                    {
                        jenericJson.value = new List<GenericJson>();
                    }
                    label1.Text += deep + "StartObject\n";
                    if (!reader.Read()) return;
                    while (str != "EndObject")
                    {
                        str = reader.TokenType.ToString();
                        //label1.Text += "!!! " + str + "\n";
                        (jenericJson.value as List<GenericJson>).Add(new GenericJson());
                        await ReadJson(reader, (jenericJson.value as List<GenericJson>)[(jenericJson.value as List<GenericJson>).Count - 1], deep + " ");
                        //if (!reader.Read()) return;
                    }
                    //await ReadJson(reader, jenericJson);
                    break;
                case "StartArray":
                    if (jenericJson.value == null)
                    {
                        jenericJson.value = new List<GenericJson>();
                    }
                    label1.Text += deep + "StartArray\n";
                    if (!reader.Read()) return;
                    while (str != "EndArray")
                    {
                        str = reader.TokenType.ToString();
                        //label1.Text += ">>> " + str + "\n";
                        (jenericJson.value as List<GenericJson>).Add(new GenericJson());
                        await ReadJson(reader, (jenericJson.value as List<GenericJson>)[(jenericJson.value as List<GenericJson>).Count - 1], deep + " ");
                        //if (!reader.Read()) return;
                    }
                    break;
                case "PropertyName":
                    if (jenericJson.value == null)
                    {
                        //jenericJson.value = new List<GenericJson>();
                    }
                    str = reader.Value.ToString();
                    label1.Text += deep + "PropertyName: " + str + "\n";
                    //(jenericJson.value as List<GenericJson>).Add(new GenericJson());
                    //(jenericJson.value as List<GenericJson>)[(jenericJson.value as List<GenericJson>).Count - 1].key = str;
                    jenericJson.key = str;
                    if (!reader.Read()) return;
                    //await ReadJson(reader, (jenericJson.value as List<GenericJson>)[(jenericJson.value as List<GenericJson>).Count - 1], deep + " ");
                    await ReadJson(reader, jenericJson, deep);
                    break;
                case "String":
                    str = reader.Value.ToString();
                    label1.Text += deep + "String: " + str + "\n";
                    jenericJson.value = str;
                    if (!reader.Read()) return;
                    //await ReadJson(reader, jenericJson);
                    break;
                case "Integer":
                    str = reader.Value.ToString();
                    label1.Text += deep + "Integer: " + str + "\n";
                    jenericJson.value = str;
                    if (!reader.Read()) return;
                    //await ReadJson(reader, jenericJson);
                    break;
                default:
                    //label1.Text += "<<< Skip " + reader.TokenType + "\n";
                    if (!reader.Read()) return;
                    //await ReadJson(reader, jenericJson);
                    break;
            }
            //label1.Text += "<<<<<<<<<<<<<<<<<<<<<<<<<\n";
        }

        private async Task PrintParsedJson(GenericJson jenericJson, string deep = "")
        {
            if (jenericJson.value == null)
                return;
            if (jenericJson.key != "")
                label1.Text += deep + "key: \"" + jenericJson.key + "\" ";
            if ( jenericJson.value.GetType() == typeof(List<GenericJson>) )
            {
                if (jenericJson.key == "")
                    label1.Text += deep + "[\n";
                else
                    label1.Text += "\n" + deep + "{\n";
                foreach (var item in (jenericJson.value as List<GenericJson>))
                {
                    await PrintParsedJson(item, deep + "    ");
                }
                if (jenericJson.key == "")
                    label1.Text += deep + "]\n";
                else
                    label1.Text += deep + "}\n";
            }
            else if (jenericJson.value != null)
            {
                label1.Text += ", value = " + jenericJson.value.ToString() + "\n";
            }
        }

        private async Task GetImagesFromJson(JsonTextReader reader)
        {
            while (reader.ReadAsync().Result)
            {
                if (reader.Value != null)
                {
                    //label1.Text += reader.TokenType + ": " + reader.Value + "\n";
                    if (reader.Value.ToString().Contains("photo_"))
                    {
                        await reader.ReadAsync();
                        Image image = new Image();
                        image.Source = reader.Value.ToString();
                        //image.Source = new Uri(reader.Value.ToString());
                        //image.Source = ImageSource.FromUri(new Uri(reader.Value.ToString()));
                        //image.Source = new UriImageSource { CachingEnabled = false, Uri = new Uri(reader.Value.ToString()) };
                        imagesStack.Children.Add(image);
                    }
                }
                else
                {
                    //label1.Text += reader.TokenType + "\n";
                }
            }
        }

        private async void Auth_Clicked(object sender, EventArgs e)
        {// Пример авторизации в vk.com через GET запрос

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Да, такой ебанутый API, но для примера катит
                    string url = "https://oauth.vk.com/token?grant_type=password&client_id=3140623&client_secret=VeWdmVclDCtn6ihuP1nt&username=" + login.Text + "&password=" + password.Text;

                    // Производим авторизацию
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Дожидаемся ответа
                    response.EnsureSuccessStatusCode();

                    // Считываем ответ
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Вот тут уже JSON в формате строки преобразуем в наш ламповый класс
                    VKJson json = JsonConvert.DeserializeObject<VKJson>(responseBody);

                    // Показываем наш модный попап
                    popupLoginView.IsVisible = false;

                    label1.Text = "token: " + json.access_token + "\n"; // "\n" - перенос строки
                    label1.Text += "expires_in: " + json.expires_in + "\n";
                    label1.Text += "user_id: " + json.user_id + "\n\n";

                    // Получаем новостную ленту
                    HttpResponseMessage response1 = await client.GetAsync("https://api.vk.com/method/newsfeed.get?user_id=" + json.user_id + "&filters=post&count=100&v=5.92&access_token=" + json.access_token);

                    // Дожидаемся ответа
                    response1.EnsureSuccessStatusCode();

                    // Считываем ответ
                    string responseAsString = await response1.Content.ReadAsStringAsync();

                    //label1.Text += responseAsString + "\n\n";

                    NewsJson kek = JsonConvert.DeserializeObject<NewsJson>(responseAsString);

                    label1.Text += kek.GetJson() + "\n\n";

                    await Navigation.PushAsync(new News(kek));

                    // Создаем реадер
                    //JsonTextReader reader = new JsonTextReader(new StringReader(responseAsString));

                    // Вызываем нашу функцию, которая вытащит картинки из реадера
                    //GetImagesFromJson(reader);

                    // Создаем реадер с теми же данными
                    //JsonTextReader reader2 = new JsonTextReader(new StringReader(responseAsString));

                    // Тут создается основание дерева
                    //GenericJson kek = new GenericJson();

                    // Считываем json в наше дерево
                    //await ReadJson(reader2, kek);
                    //label1.Text += "\n\n";

                    // Выводим результат
                    //await PrintParsedJson(kek);
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
