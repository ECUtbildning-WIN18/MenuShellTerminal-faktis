using System.Collections.Generic;
using System.Data.SqlClient;
using Domain;

namespace MenuShellTerminal
{
    public class Sql
    {
        public void InitSql()
        {
            var connectionString = "Data Source=(local);Initial Catalog=MenuShell; Integrated Security=true";
            using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                connection.Open();
                var customerElements = new List<string>();
                var customerColumn = new SqlCommand("SELECT * FROM [User]", connection);
                var reader = customerColumn.ExecuteReader();

                if (!reader.HasRows) return;
                while (reader.Read())
                    for (var i = 0; i < reader.FieldCount; i++)
                        customerElements.Add(reader[i].ToString());

                for (var i = 0; i < customerElements.Count; i+=3)
                {
                    if (Database.UserNames.Contains(customerElements[i])) return;
                    Database.UserNames.Add(customerElements[i]);
                    if (customerElements[i+2] == "SystemAdministrator")
                    {
                        
                        Database.Users.Add(customerElements[i],
                            new SystemAdministrator(customerElements[i],
                                customerElements[i+1])); 
                    }
                    else if (customerElements[i+2] == "Customer")
                    {
                        Database.Users.Add(customerElements[i],
                            new Customer(customerElements[i],
                                customerElements[i+1])); 
                    }
                }
            }
        }
    }
}