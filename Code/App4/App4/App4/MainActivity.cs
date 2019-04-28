using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.Wearable.Views;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.Wearable.Activity;
using Java.Interop;
using Android.Views.Animations;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Timers;

namespace App4
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : WearableActivity
    {
        public void RefreshWeather()
        {
            string token = "d827fff2c3d14e37ebf57321e477e96f";
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Yakutsk&APPID=" + token;
            try
            {
                // Создаем реквест
                HttpWebRequest httpWebRequest = new HttpWebRequest(new Uri(url));
                // Получаем респонз и из него получаемстрим
                var jsonStream = new StreamReader(httpWebRequest.GetResponse().GetResponseStream());
                // Считываем стрим до конца в строку
                var json = jsonStream.ReadToEnd();
                // Разбираем Json в класс
                dynamic weatherClass = JsonConvert.DeserializeObject(json);
                // Обновляем температуру
                FindViewById<TextView>(Resource.Id.text).Text = ((int)weatherClass.main.temp - 273).ToString() + " C";
            }
            catch
            {
                // В случае ошибки
                FindViewById<TextView>(Resource.Id.text).Text = "Ошибка загрузки данных с сервера";
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_main);

            SetAmbientEnabled();

            // Добавлено
            // Запускаем тред с обновлениемтемпературы
            RunOnUiThread(async () =>
            {
                while (true)
                {
                    // Функция обновления температуры
                    RefreshWeather();
                    // Ждем секунду
                    await Task.Delay(10000);
                }
            });
        }
    }
}


