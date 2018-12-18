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
