using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
    public class MenuItemKek
    {
        public int Id { get; set; }
        public string name { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {

        public Page2()
        {
            InitializeComponent();
            List<MenuItemKek> a = new List<MenuItemKek>();
            a.Add(new MenuItemKek { Id = 0, name = "abc" });
            a.Add(new MenuItemKek { Id = 1, name = "cba" });
            a.Add(new MenuItemKek { Id = 2, name = "bca" });

            ListView1.ItemsSource = a;

        }
        

    } 
        
}
    