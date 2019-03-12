# Урок 2 - ContentPage StackLayout

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)

## Виды страниц наглядно

<img src="https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/user-interface/controls/pages-images/pages.png#lightbox" width="800">

## ContentPage

Самый простой вид страниц из доступных

<img src="https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/user-interface/controls/pages-images/ContentPage-Large.png#lightbox" width="800">

## Виды макетов наглядно

<img src="https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/user-interface/controls/layouts-images/layouts.png#lightbox" width="800">

## ContentPage

Самый простой вид макета из доступных

<img src="https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/user-interface/controls/layouts-images/ContentView-Large.png#lightbox" width="800">

## Frontend

```xaml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" 
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MyApp.View2">
    <!-- ContentPage - одина из самых простых страниц
    В ContentPage.Content Кладется макет -->
    <ContentPage.Content>
        <!-- StackLayout - один из видов макетов. Например этот складывает все объекты в ряд
        HorizontalOptions - указывает на то, что объекты внутри макета будут по центу слева направо
        VerticalOptions   - указывает на то, что объекты внутри макета будут по центу сверху вниз  -->
        <StackLayout HorizontalOptions="Center" VerticalOptions="Center" BackgroundColor="#00ff00" >
            <!-- Кнопка. Button_Clicked - функция, которая будет вызываться при клике
            на кнопку. Ее реализация создалась в файле View2.xaml.cs -->
            <Button Clicked="Button_Clicked"></Button>
            <!-- Просто текст, который отображается на странице.
            С помощью x:Name мы управляем лейблом из файла View2.xaml.cs -->
            <Label Text="xdtjssjmcytxmtx"  HorizontalOptions="Center" VerticalOptions="StartAndExpand" x:Name="label1"/>
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

// namespace - это пространство, в котором мы объявляем классы
namespace MyApp
{
    // Публичный класс страницы
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View2 : ContentPage
    {
        // Конструктор класса
        public View2 ()
        {
            // Инициализирует компаненты из файла с расширением xaml
            InitializeComponent();
        }

        // Реализация функции, которая вызывается при нажатии на кнопку
        // Она привязывается в файле xaml
        private void Button_Clicked(object sender, EventArgs e)
        {
            // label1 указан в Label в поле x:Name. Этот Label инициализирован в файле View2.xaml
            label1.Text = "Hello world!!!";
        }
    }
}
```

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)
