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

namespace MyApp.Droid
{
    class DangerousClass : IAuth
    {
        IAuthResult user;
        public async Task<string> LogIn(string L, string P)
        {
         user = await FirebaseAuth.Instance.SignInAnonymouslyAsync();
           var ttt = await user.User.GetIdTokenAsync(false);
            return ttt.Token;
        }
    }
}