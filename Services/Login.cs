﻿using Domain;

namespace Services
{
    public class Login
    {
        public string TryLogin(string userName, string passWord)
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
