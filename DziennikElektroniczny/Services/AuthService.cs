using DziennikElektroniczny.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.Services
{
    public class AuthService
    {

        public bool AuthenticateCredentials(LoginView loginView)
        {
            if(loginView.Login == "szymon" && loginView.Password == "123")
            {
                return true;
            }

            return false;
        }
    }
}
