using FirebaseAuthentication;
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
        public static IFirebaseAuthenticator user = null;
        bool inited = false;

        // Конструктор класса
        public View2 ()
        {
            // Инициализирует компаненты из файла с расширением xaml
            InitializeComponent();
            if (user == null)
            {
                InitSign();
            }
            else
            {
                InitProfile();
            }
            inited = true;
        }

        void InitSign()
        {
            Button auth = new Button();
            auth.Text = "Sign in";
            auth.Clicked += Auth_Clicked;
            layout1.Children.Add(auth);

            Button registr = new Button();
            registr.Text = "Sign up";
            registr.Clicked += Register_Clicked;
            layout1.Children.Add(registr);
        }

        void InitProfile()
        {
            Label labelEmail = new Label();
            labelEmail.Text = user.Email;
            layout1.Children.Add(labelEmail);

            Label labelName = new Label();
            labelName.Text = user.Name;
            layout1.Children.Add(labelName);

            Label labelSecondName = new Label();
            labelSecondName.Text = user.SecondName;
            layout1.Children.Add(labelSecondName);

            Button logout = new Button();
            logout.Text = "Logout";
            logout.Clicked += Logout_Clicked;
            layout1.Children.Add(logout);
        }

        void RemoveItems()
        {
            layout1.Children.Clear();
        }

        private void Auth_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View3());
        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page4());
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {
            user = null;
            RemoveItems();
            InitSign();
        }

        protected override void OnAppearing()
        {
            if (inited)
            {
                if (user == null)
                {
                    RemoveItems();
                    InitSign();
                }
                else
                {
                    RemoveItems();
                    InitProfile();
                }
            }
        }
    }
}