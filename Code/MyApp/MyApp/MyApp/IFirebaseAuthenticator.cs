using System;
using System.Threading.Tasks;

namespace FirebaseAuthentication
{
    public interface IFirebaseAuthenticator
    {
        // Поля хранят в себе данные после считывания из базы
        string Token { get; set; }
        string Email { get; set; }
        string Name { get; set; }
        string SecondName { get; set; }

        // Логинимся анонимно
        Task<string> LoginWithEmailAnonymously();

        // Логинимся с логином и паролем
        Task<string> LoginWithEmailPassword(string email, string password);

        // Регистрируемся
        Task<string> RegsiterWithEmailPassword(string email, string password, string name, string secondName);

        // Получаем данные из базы
        Task<IFirebaseAuthenticator> GetDataFromDataBase(string token);
    }
}