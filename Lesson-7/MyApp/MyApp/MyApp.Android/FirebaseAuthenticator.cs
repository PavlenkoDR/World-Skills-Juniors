using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using FirebaseAuthentication;
using Xamarin.Forms;

[assembly: Dependency(typeof(MyApp.Droid.FirebaseAuthenticator))]
namespace MyApp.Droid
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            IAuthResult user;
            try
            {
                user = await FirebaseAuth.Instance.
                             SignInWithEmailAndPasswordAsync(email, password);
            }
            catch (Exception)
            {
                return "user error";
            }
            GetTokenResult token;
            try
            {
                token = await user.User.GetIdTokenAsync(false);
            }
            catch (Exception)
            {
                return "token error";
            }
            return token.Token;
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
                return "user error";
            }
            GetTokenResult token;
            try
            {
                token = await user.User.GetIdTokenAsync(false);
            }
            catch (Exception)
            {
                return "token error";
            }
            return token.Token;
        }

        public async Task<string> RegsiterWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.
                                                CreateUserWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }
    }
}