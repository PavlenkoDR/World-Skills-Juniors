# Урок 3 - Создание меню MasterDetailPage

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)

## MasterDetailPage

Страница MasterDetailPage содержит в себе две части: Master и Detail.

* Master - это выдвигающееся меню
* Detail - отображаемая страница с контентом

<img src="https://docs.microsoft.com/ru-ru/xamarin/xamarin-forms/user-interface/controls/pages-images/MasterDetailPage-Large.png#lightbox" width="800">

## Frontend

```xaml
<?xml version="1.0" encoding="utf-8" ?>
<MasterDetailPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:MyApp"
             x:Class="MyApp.MainPage"
             Title="name">
    <!-- В некоторых случает Title отображается в шапке. Указываем на всякий случай -->

    <!-- MasterDetailPage состоит из Master и Detail частей
    Master - это выдвигающееся меню
    Detail - отображаемая страница с контентом -->
    
    <!-- Контент -->
    <MasterDetailPage.Detail>
        <!-- С помощью NavigationPage переключаем страницы
        подробнее в файле MainPage.xaml.cs -->
        <NavigationPage>
            <!-- Данную конструкцию можно подсмотреть в шаблоне проекта MasterDetailPage
            в папке Views в файле MainPage.xaml -->
            <x:Arguments>
                <!-- Page3 - отображаемая страница -->
                <local:Page3/>
            </x:Arguments>
        </NavigationPage>
    </MasterDetailPage.Detail>
    
    <!-- Меню -->
    <MasterDetailPage.Master>
        <!-- В меню кладем страницу, которая будет отображаться при нажатии на гамбургер.
        Гамбургер - кнопка с тремя полосками слева сверху -->
        <ContentPage Title="name2">
            <!-- В ContentPage.Content Кладется макет -->
            <ContentPage.Content>
                <!-- StackLayout - один из видов макетов. Например этот складывает все объекты в ряд -->
                <StackLayout Padding="35, 15, 35, 15">
                    <!-- Очевидно кнопки. Button_Clicked - функция, которая будет вызываться при клике
                    на кнопку. Ее реализация создалась в файле MainPage.xaml.cs -->
                    <Button Text="Buuu" Clicked="Button_Clicked"></Button>
                    <Button Text="asas" Clicked="Button_Clicked_2"></Button>
                    <Button Text="cxxcv"></Button>
                    <Button Text="hello" Clicked="Button_Clicked_1"></Button>
                </StackLayout>
            </ContentPage.Content>
        </ContentPage>
    </MasterDetailPage.Master>
</MasterDetailPage>
```

## Backend

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

// namespace - это пространство, в котором мы объявляем классы
namespace MyApp
{
    // Публичный класс страницы
    public partial class MainPage : MasterDetailPage
    {
        // Конструктор класс
        public MainPage()
        {
            // Инициализирует компаненты из файла с расширением xaml
            InitializeComponent();
        }

        // Реализация функции, которая вызывается при нажатии на кнопку
        // Она привязывается в файле xaml
        private void Button_Clicked(object sender, EventArgs e)
        {
            // Detail - это основная страница MasterDetailPage
            // Тут мы создаем ей новый NavigationPage
            // в который помещаем страницу View2
            Detail = new NavigationPage(new View2());
            // Сворачивает меню
            IsPresented = false;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new View3());
            IsPresented = false;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new View1());
            IsPresented = false;
        }
    }
}

```

[World-Skills-Juniors](https://pavlenkodr.github.io/World-Skills-Juniors/)
