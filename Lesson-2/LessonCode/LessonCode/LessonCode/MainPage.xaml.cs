using Xamarin.Forms;

namespace LessonCode
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage( new News() );
            IsPresented = false;
        }

        private void Button_Clicked_1(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage( new Members() );
            IsPresented = false;
        }
    }
}
