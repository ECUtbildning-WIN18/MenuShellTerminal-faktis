using System;
using System.Collections.Generic;
using Domain;

namespace Domain
{
    public class Database
    {
        public static HashSet<string> UserNames { get; set; } = new HashSet<string>() { "Admin" };
        public static Dictionary<string, User> Users { get; set; } = new Dictionary<string, User>();
        public Database()
        {
            Users.Add("Admin", new SystemAdministrator("Admin", "PassWord"));
        }
        
    }
}
