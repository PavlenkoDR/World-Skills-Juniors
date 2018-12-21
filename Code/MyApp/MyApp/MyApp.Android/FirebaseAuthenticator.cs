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

    // Наследуемся от IValueEventListener и Java.Lang.Object. Это важно
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

        // Реализуем функцию, объявленную в интерфейсе IValueEventListener.
        // Она будет искать наши данные
        public void OnDataChange(DataSnapshot snapshot)
        {
            try
            {
                // Получаем всех детей-наследников объекта, на которого вешался слушатель
                var children = snapshot.Children.ToEnumerable<DataSnapshot>();

                // Временно хранит данные пользователя
                User ret = new User();

                // Пробегаемся по всем потомкам и забиваем нашу переменную ret
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
                // После того, как все считали, кладем наши данные в data
                data = new User(ret);
            }
            catch
            {
                data = null;
            }
        }

        // Эта функция ожидает, когда в data что-то появится
        public async Task<User> GetValueAsync()
        {
            // StartNew(() => { Тут наш код })
            // Этот код будет исполняться в отдельном потоке
            // Поэтому приложение не зависнет
            return await Task.Factory.StartNew(() =>  // вложенная задача
            {
                // Ждем когда в data что-нибудь положат
                while (data == null) { }
                // Тырим данные
                User ret = data;
                // Обнуляем данные
                data = null;
                // Скидываем стыренное
                return ret;
            });
        }
    }

    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        // Поля, объявленные в интерфейсе.
        // Будут хранить в себе данные после считывания из базы
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

        // Функция полчения данных из базы
        public async Task<IFirebaseAuthenticator> GetDataFromDataBase(string email)
        {
            // Проделываем уже знакомые операции
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

            // Будет временно хранить данные, считанные из базы
            User data;
            Email = "empty";
            try
            {
                // Создаем объект класса-слушателя, который будет рыскать по базе в поисках данных
                var listener = new UserValueEventListener();

                child = databaseReference.Child(email);

                // Добавляем нашего рыскателя
                child.AddListenerForSingleValueEvent(listener);

                // Вызываем функцию, которая ждет, пока слушатель получит данные
                data = await listener.GetValueAsync();

                // Забиваем полученные данные в класс, из которого вызывался метод
                // То есть, обратите внимание, мы кладем прям в Name, SecondName и т.д
                // Которые объявлены в IFirebaseAuthenticator
                Name = data.Name;
                SecondName = data.SecondName;
                Email = data.Email;
                Token = data.Token;
            }
            catch
            {
                throw new ArgumentException("Get data error");
            }
            // И возвращаем объект класса, из которого вызывалась функция
            return this;
        }
    }
}