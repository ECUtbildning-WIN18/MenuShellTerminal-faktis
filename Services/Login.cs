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
                    var loginMessage = TryLogin(userName, passWord);
                    if (loginMessage == "LogIn")
                    {

                        if (Globals.ActiveUser.UserType == UserType.SystemAdministrator)
                        {
                            return "SystemAdministrator";
                        }
                        else if (Globals.ActiveUser.UserType == UserType.Customer)
                        {
                            return "Customer";
                        }
                    }
                    else
                    {

                        return loginMessage;
                    }
                    return "AgainMyself";
                case ConsoleKey.N:
                    return "AgainMyself";
            }
            return "AgainMyself";

        }

        public static string TryLogin(string userName, string passWord)
        {

            using (var db = new MenuShellContext())
            {

                
                var user = GetUserWithUserName(userName);
                if (user == null) return "Did not find user with name";
                
                if (user != null && user.PassWordPass(passWord))
                {
                    Globals.ActiveUser = user;
                    return "LogIn";
                }
                
                else return "Wrong password";



            }
        }
     

        private static User GetUserWithUserName(string username)
        {
            using (var context = new MenuShellContext())
            {
                foreach (var customer in context.Customer)
                {
                    if (customer.UserName == username) return customer;
                }
                foreach (var admin in context.Admin)
                {
                    if (admin.UserName == username) return admin;
                }
            }
            return null;
        }
    }
}
