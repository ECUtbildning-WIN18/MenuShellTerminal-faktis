using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Domain;

namespace Services
{
    public class DeleteUser
    {
        public void Delete(string userName)
        {
            var connectionString = "Data Source=(local);Initial Catalog=MenuShell; Integrated Security=true";
            using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command= new SqlCommand($"DELETE FROM [User] WHERE UserName ='{userName}'", connection);
                command.ExecuteNonQuery();
                Database.Users.Remove(userName);
                Database.UserNames.Remove(userName);
            }
        }
    }
}
