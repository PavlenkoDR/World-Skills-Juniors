using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Fullimg : ContentPage
	{
		public Fullimg ()
		{
			InitializeComponent ();
		}

        public Fullimg(ImageSource source)
        {
            InitializeComponent();
            Mainimg.Source = source;
        }
    }
}