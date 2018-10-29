using System;
using Domain;

namespace Services
{    public static class CreateUser
    {
        public static string CreateController(ConsoleKey key, string userName, string passWord, string userType)
        {
            switch (key)
            {
                case ConsoleKey.Y:
                    var createMessage = TryCreate(userName, passWord, userType);
                    if (createMessage == "Created")
                    {
                            return "SystemAdministrator";
                    }
                    else
                    {
                        return createMessage;
                    }
                case ConsoleKey.Escape:
                    return "SystemAdministrator";
                case ConsoleKey.N:
                    break;
                

            }
            return "AgainMyself";
        }
        
    
        public static string TryCreate(string userName, string passWord, string userType)
        {

            if (!Database.UserNames.Contains(userName))
            {
                switch (userType)
                {
                    case "Customer":
                        Database.Users.Add(userName, new Customer(userName, passWord));
                        Database.UserNames.Add(userName);
                        return "Created";
                    case "Admin":
                        Database.Users.Add(userName, new SystemAdministrator(userName, passWord));
                        Database.UserNames.Add(userName);
                        return "Created";
                    default:
                        return userType + " is NOT a valid type.\n" +
                            "Valid types are:\n" +
                            "Customer, Admin";

                }
                
                //XElement User =
                //    new XElement("User",
                //    new XElement("Name", userName),
                //    new XElement("Type", userType),
                //    new XElement("PassWord", Database.Users[userName].SaltHashPassWord));
                
                //Database.UsersXML.Root.Add(User);
                //Database.UsersXML.Save("Users.xml");

            }
            else
            {
                return "User with given UserName already exist";
            }
        }
    }
}
