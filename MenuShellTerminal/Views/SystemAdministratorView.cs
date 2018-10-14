using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace MenuShellTerminal.Views
{
    class SystemAdministratorView : View
    {
        public override View ViewIt()
        {
            Console.Clear();
            Console.Title = "SystemAdministrator";
            Console.WriteLine("-----Options-----");
            Console.WriteLine("(A)dd User");
            Console.WriteLine("(D)elete User");
            Console.WriteLine("(L)og Out");
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.A:
                    return new AddUserView();
                case ConsoleKey.D:
                    Console.Clear();
                    Console.WriteLine("-----Users-----");
                    foreach(string user in Database.UserNames)
                    {
                        Console.WriteLine(user);
                    }
                    Console.WriteLine("UserName of the one you want to delete: ");
                    var userName =  Console.ReadLine();
                    if (Database.UserNames.Contains(userName))
                    {
                        return new DeleteUserView(userName);
                    }
                    return this;
                case ConsoleKey.L:
                    return new LoginView();
            }
            return this;
        }
    }
}
