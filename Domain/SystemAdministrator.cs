//using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class SystemAdministrator : User
    {
        public SystemAdministrator(string userName, string passWord) : base(userName, passWord, UserType.SystemAdministrator) { }
   
        /*public User AddUser(string userName, string passWord, UserType userType)
        {
            User user = null;
            if(userType == UserType.Customer)
            {
                user =  new Customer(userName, passWord);
            }
            return user; 
        }*/
    }
}
