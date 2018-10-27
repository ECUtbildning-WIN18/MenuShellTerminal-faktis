using Domain;
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
                    break;
                case ConsoleKey.N:
                    break;
            }
            return "AgainMyself";
        }

        public static string TryLogin(string userName, string passWord)
        {
            if (Database.UserNames.Contains(userName))
            {
                if (Database.Users[userName].PassWordPass(passWord))
                {
                    Globals.ActiveUser = Database.Users[userName];
                    return "LogIn";
                }
                else
                {
                    return "Wrong password";
                }
            }
            else
            {
                return "User with given UserName does not exist";

            }
        }
    }
}
