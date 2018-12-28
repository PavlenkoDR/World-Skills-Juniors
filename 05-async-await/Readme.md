# Урок 5 - async await

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)

Очень подробно в видео с 4:35. Но лучше посмотреть сначала

[Ссылка на видео](https://www.youtube.com/watch?v=8NAROILdizw)

## Frontend

```xaml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MyApp.Page1">
    <ContentPage.Content>
        <StackLayout HorizontalOptions="Center" VerticalOptions="Center" x:Name="im">
            <Label Text="Welcome to Xamarin.Forms!"
                VerticalOptions="CenterAndExpand" 
                HorizontalOptions="CenterAndExpand"/>
            <!-- Opacity - Прозрачность. 0.5 - 50% -->
            <Image Source="icon.png" Opacity="0.5" ></Image>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

## Backend

```cs
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
```

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)
