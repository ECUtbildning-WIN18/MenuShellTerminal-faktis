using Domain;
using Domain.Contexts;
using System;

namespace Services
{
    public static class Login
    {
        public static string LoginController(ConsoleKey key, string userName, string passWord)
        {
            switch (key)
            {
                case ConsoleKey.Y:
                {
                    var loginMessage = TryLogin(userName, passWord);
                    if (loginMessage == "LogIn")
                    {
                        switch (Globals.ActiveUser.UserType)
                        {
                            case UserType.SystemAdministrator:
                                return "SystemAdministrator";
                            case UserType.Customer:
                                return "Customer";
                        }
                    }

                    return loginMessage;
                }
                case ConsoleKey.N:
                    return "AgainMyself";
                default:
                    return "AgainMyself";
            }
        }

        private static string TryLogin(string userName, string passWord)
        {
            using (var db = new MenuShellContext())
            {
                var user = SearchAndFind.GetUserWithUserName(userName);
                if (user == null) return "Did not find user with name";

                if (!user.PassWordPass(passWord)) return "Wrong password";
                
                Globals.ActiveUser = user;
                return "LogIn";
            }
        }
    }
}
