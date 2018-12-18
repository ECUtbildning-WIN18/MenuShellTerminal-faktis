using Domain;
using Domain.Contexts;
using System;

namespace Services
{
    public static class CreateUser
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


        public static string TryCreate(string userName, string password, string userType,
            string firstName = "???", string lastName = "???", string socialSecurityNumber = "???")
        {
            using (var db = new MenuShellContext())
            {
                if (SearchAndFind.GetUserWithUserName(userName) == null)
                {
                    switch (userType)
                    {
                        case "Customer":
                            var customer = new Customer( userName, password);
                            db.Customer.Add(customer);
                            db.SaveChanges();
                            return "Created";
                        case "Admin":
                            var admin = new SystemAdministrator(userName, password);
                            db.Admin.Add(admin);
                            db.SaveChanges();
                            return "Created";
                        default:
                            return userType + " is NOT a valid type.\n" +
                                   "Valid types are:\n" +
                                   "Customer, Admin";
                    }
                }
                else
                {
                    return "User with given UserName already exist";
                }
            }
        }

        
    }
}