using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Android.Resource;

namespace MyApp
{
    public class MenuItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
    }

    public partial class MainPage : MasterDetailPage
    {


        public MainPage()
        {
            InitializeComponent();
            List<MenuItem> menuItemArray = new List<MenuItem>
            {
                new MenuItem {id = 0, name="Browse", color = "Blue" },
                new MenuItem {id = 1, name="About", color = "Blue" },
                new MenuItem {id = 2, name="Kavo", color = "Blue" },
            };
            listView1.ItemsSource = menuItemArray;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new View2());
            IsPresented = false;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new View3());
            IsPresented = false;
        }

        private void ListView1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var a = e.SelectedItem as MenuItem;
        }
    }
}
