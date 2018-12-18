using System;
using System.Threading.Tasks;

namespace FirebaseAuthentication
{
    public interface IFirebaseAuthenticator
    {
        Task<string> LoginWithEmailAnonymously();                              // Логинимся анонимно
        Task<string> LoginWithEmailPassword(string email, string password);    // Логинимся с логином и паролем
        Task<string> RegsiterWithEmailPassword(string email, string password); // Регистрируемся
    }
}