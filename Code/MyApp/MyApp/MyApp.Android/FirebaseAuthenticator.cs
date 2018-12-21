using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase.Database;
using FirebaseAuthentication;
using Xamarin.Forms;

/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
///                 ОЧЕНЬ ВАЖНАЯ СТРОЧКА                      ///
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////
///   VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV   ///
[assembly: Dependency(typeof(MyApp.Droid.FirebaseAuthenticator))]
namespace MyApp.Droid
{
    public class User : Java.Lang.Object
    {
        public User()
        {
        }

        public User(User ret)
        {
            Token = ret.Token;
            Email = ret.Email;
            Name = ret.Name;
            SecondName = ret.SecondName;
        }

        public string Token { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
    }

    public class UserValueEventListener : Java.Lang.Object, IValueEventListener
    {
        EventHandler OnChange;

        public UserValueEventListener()
        {
        }

        public UserValueEventListener(EventHandler OnChange) => this.OnChange = OnChange;

        public void OnCancelled(DatabaseError error)
        {
            //Log.Warn(App.TAG, "Failed to read value:", error.ToException());
        }

        private User data = null;

        public void OnDataChange(DataSnapshot snapshot)
        {
            try
            {
                var children = snapshot.Children.ToEnumerable<DataSnapshot>();
                User ret = new User();
                foreach (var c in children)
                {
                    if (c.Key == "Name")
                    {
                        ret.Name = c.GetValue(true).ToString();
                    }
                    if (c.Key == "Email")
                    {
                        ret.Email = c.GetValue(true).ToString();
                    }
                    if (c.Key == "SecondName")
                    {
                        ret.SecondName = c.GetValue(true).ToString();
                    }
                }
                data = new User(ret);
            }
            catch
            {
                data = null;
            }
        }

        public async Task<User> GetValueAsync()
        {
            return await Task.Factory.StartNew(() =>  // вложенная задача
            {
                while (data == null) { }
                User ret = data;
                data = null;
                return ret;
            });
        }
    }

    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }

        // Реализация функции из интерфейса IFirebaseAuthenticator
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            // В этой переменной будет храниться результат авторизации
            IAuthResult authResult;
            try
            {
                authResult = await FirebaseAuth.Instance.
                             SignInWithEmailAndPasswordAsync(email, password);
            }
            catch (Exception)
            {
                // Тут кидаем свое исключение с самопальным сообщением.
                // Обрабатываться оно будет в месте где вызывалась функция LoginWithEmailPassword( ... )
                throw new ArgumentException("SignInWithEmailAndPasswordAsync error");
            }
            // В этой переменной будет храниться результат получения токена
            GetTokenResult tokenResult;
            try
            {
                tokenResult = await authResult.User.GetIdTokenAsync(false);
            }
            catch (Exception)
            {
                throw new ArgumentException("GetIdTokenAsync error");
            }
            return tokenResult.Token;
        }

        public async Task<string> LoginWithEmailAnonymously()
        {
            IAuthResult user;
            try
            {
                user = await FirebaseAuth.Instance.
                             SignInAnonymouslyAsync();
            }
            catch (Exception)
            {
                throw new ArgumentException("SignInAnonymouslyAsync error");
            }
            GetTokenResult token;
            try
            {
                token = await user.User.GetIdTokenAsync(false);
            }
            catch (Exception)
            {
                throw new ArgumentException("GetIdTokenAsync error");
            }
            return token.Token;
        }

        public async Task<string> RegsiterWithEmailPassword(string email, string password, string name, string secondName)
        {
            var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);

            // Хранит в себе ссылку на базу
            FirebaseDatabase firebaseDatabase;

            // Хранит в себе ссылку на таблицу
            DatabaseReference databaseReference;

            // Будет использоваться для хранения промежуточных таблиц
            DatabaseReference child;
            try
            {
                // Получаем нашу базу
                firebaseDatabase = FirebaseDatabase.GetInstance("https://worldskills-f19d1.firebaseio.com/");
            }
            catch
            {
                throw new ArgumentException("GetInstance error");
            }
            try
            {
                // Получаем таблицу "worldskills-f19d1"
                databaseReference = firebaseDatabase.GetReference("worldskills-f19d1");
            }
            catch
            {
                throw new ArgumentException("GetReference error");
            }

            // Хранит в себе данные о регистрации
            User newUser;
            try
            {
                newUser = new User();
                //newUser.Token = token.Token.Replace(".", "tochka");

                //Заполняем нашего нового юзера
                newUser.Token = email.Replace('@', 'a').Replace('.', 'b');
                newUser.Email = email;
                newUser.Name = name;
                newUser.SecondName = secondName;

                // Получаем таблицу нашего нового юзера
                child = databaseReference.Child(newUser.Token);
            }
            catch
            {
                throw new ArgumentException("Add child error");
            }
            try
            {
                // Записываем данные в базу
                await child.Child("Email").SetValueAsync(newUser.Email);
                await child.Child("Name").SetValueAsync(newUser.Name);
                await child.Child("SecondName").SetValueAsync(newUser.SecondName);
            }
            catch
            {
                throw new ArgumentException("Add data error");
            }
            return newUser.Token;
        }

        public async Task<IFirebaseAuthenticator> GetDataFromDataBase(string email)
        {
            email = email.Replace('@', 'a').Replace('.', 'b');

            DatabaseReference databaseReference;
            FirebaseDatabase firebaseDatabase;

            DatabaseReference child;
            try
            {
                firebaseDatabase = FirebaseDatabase.GetInstance("https://worldskills-f19d1.firebaseio.com/");
            }
            catch
            {
                throw new ArgumentException("GetInstance error");
            }
            try
            {
                databaseReference = firebaseDatabase.GetReference("worldskills-f19d1");
            }
            catch
            {
                throw new ArgumentException("GetReference error");
            }

            User data;
            Email = "empty";
            try
            {
                var listener = new UserValueEventListener();

                child = databaseReference.Child(email);

                child.AddListenerForSingleValueEvent(listener);

                data = await listener.GetValueAsync();

                Name = data.Name;
                SecondName = data.SecondName;
                Email = data.Email;
                Token = data.Token;
            }
            catch
            {
                throw new ArgumentException("Get data error");
            }
            return this;
        }
    }
}