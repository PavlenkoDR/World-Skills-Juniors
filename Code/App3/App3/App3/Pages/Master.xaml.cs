using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App3.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
        public Master()
        {
            InitializeComponent();
            
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem;
            if (item == null)
                return;

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;

            ///Detail = new NavigationPage(page);
            IsPresented = false;

           
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Detail = new News();
            IsPresented = false;


        }
    }
}