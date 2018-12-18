using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string icon { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class View1 : ContentPage
	{
		public View1 ()
        {
            InitializeComponent(); // ПИСАТЬ КОД ТОЛЬКО ПОСЛЕ ЭТОЙ ФУНКЦИИ
            List<MenuItem> menuItemArray = new List<MenuItem>
            {
                new MenuItem(){ Id = 0, title = "a1", description = "aaaaaaaaa", icon = "icon.png" },
                new MenuItem(){ Id = 1, title = "a2", description = "bbbbbbbbb", icon = "icon.png" },
                new MenuItem(){ Id = 2, title = "a3", description = "ccccccccc", icon = "icon.png" },
                new MenuItem(){ Id = 0, title = "a1", description = "aaaaaaaaa", icon = "icon.png" },
                new MenuItem(){ Id = 1, title = "a2", description = "bbbbbbbbb", icon = "icon.png" },
                new MenuItem(){ Id = 2, title = "a3", description = "ccccccccc", icon = "icon.png" },
                new MenuItem(){ Id = 0, title = "a1", description = "aaaaaaaaa", icon = "icon.png" },
                new MenuItem(){ Id = 1, title = "a2", description = "bbbbbbbbb", icon = "icon.png" },
                new MenuItem(){ Id = 2, title = "a3", description = "ccccccccc", icon = "icon.png" },
                new MenuItem(){ Id = 0, title = "a1", description = "aaaaaaaaa", icon = "icon.png" },
                new MenuItem(){ Id = 1, title = "a2", description = "bbbbbbbbb", icon = "icon.png" },
                new MenuItem(){ Id = 2, title = "a3", description = "ccccccccc", icon = "icon.png" },
            };
            listView.ItemsSource = menuItemArray;
        }
        
	}
}