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