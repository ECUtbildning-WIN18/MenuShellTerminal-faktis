using System;
using System.Data.SqlClient;
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
                var connectionString = "Data Source=(local);Initial Catalog=MenuShell; Integrated Security=true";
                using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    connection.Open();

                    switch (userType)
                    {
                        case "Customer":
                            Database.Users.Add(userName, new Customer(userName, passWord));
                            Database.UserNames.Add(userName);
                            SqlCommand command= new SqlCommand($"INSERT INTO [User] VALUES('{userName}','{passWord}','Customer')", connection);
                            try
                            {
                                command.ExecuteNonQuery();
                                
                            }
                            catch (SqlException ex)
                            {
                                return "Sql command did not work";
                            }
                            
                            return "Created";
                        case "Admin":
                            Database.Users.Add(userName, new SystemAdministrator(userName, passWord));
                            Database.UserNames.Add(userName);
                            command= new SqlCommand($"INSERT INTO [User] VALUES('{userName}','{passWord}','SystemAdministrator')", connection);
                            try
                            {
                                command.ExecuteNonQuery();
                                
                            }
                            catch (SqlException ex)
                            {
                                return "Sql command did not work";
                            }
                            return "Created";
                        default:
                            return userType + " is NOT a valid type.\n" +
                                   "Valid types are:\n" +
                                   "Customer, Admin";
                    }
                }
            }
            else
            {
                return "User with given UserName already exist";
            }
        }
    }
}
