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
            foo(); // Вызываем нашу функцию
		}

        // Завели асинхронную функцию
        async void foo()
        {
            int n = 100;
            for (int i = 0; i < n; i++)
            {
                im.Opacity = i * 1.0 / n;
                await Task.Delay(1); // Делаем задержку на 1 миллисекунду
            }
            await Task.Delay(n*2); // Делаем задержку на 200 миллисекунду
            for (int i = 0; i < n; i++)
            {
                im.Opacity = 1 - (i * 1.0 / n);
                await Task.Delay(1);
            }
            // Таким способом открываем новую страницу
            // Application - приложение
            // Current - текущее
            // MainPage - главная страница
            Application.Current.MainPage = new MainPage();
        }
	}
}