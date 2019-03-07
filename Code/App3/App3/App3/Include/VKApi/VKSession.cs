using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App3.Include.VKApi
{
    public class VKSession
    {
        public static VKUser user = new VKUser();
        public static VKNews news = new VKNews();

        private static HttpClient client = new HttpClient();

        public static void Auth(string responseBody)
        {
            user.Deserialize(responseBody);
        }

        public static async Task Auth(string login, string password)
        {
            // Пример авторизации в vk.com через GET запрос

            // Да, такой ебанутый API, но для примера катит
            string url = "https://oauth.vk.com/token?grant_type=password&client_id=3140623&client_secret=VeWdmVclDCtn6ihuP1nt&username=" + login + "&password=" + password;

            // Производим авторизацию
            HttpResponseMessage response = await client.GetAsync(url);

            // Дожидаемся ответа
            response.EnsureSuccessStatusCode();

            // Считываем ответ
            string responseBody = await response.Content.ReadAsStringAsync();

            Auth(responseBody);
        }

        public static async Task LoadNews()
        {
            string url = "https://api.vk.com/method/newsfeed.get?user_id=" + user.Get().user_id + "&filters=post&count=50&v=5.92&access_token=" + user.Get().access_token;
            
            // Получаем новостную ленту
            HttpResponseMessage response = await client.GetAsync(url);

            // Дожидаемся ответа
            response.EnsureSuccessStatusCode();

            // Считываем ответ
            string responseBody = await response.Content.ReadAsStringAsync();

            //label1.Text += responseAsString + "\n\n";

            news.Deserialize(responseBody);

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
    }
}
