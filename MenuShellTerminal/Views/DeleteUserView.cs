using System;
using System.Collections.Generic;
using System.Text;
using Services;

namespace MenuShellTerminal.Views
{
    class DeleteUserView : View
    {
        private readonly string userToBeDeleted;
        public DeleteUserView(string userName)
        {
            userToBeDeleted = userName;
        }
        public override View ViewIt()
        {
            Console.Clear();
            Console.Title = "Delete User";
            Console.WriteLine($"Delete user {userToBeDeleted} \n(Y)es or (N)o !!!");
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.Y:
                    var delete = new DeleteUser();
                    delete.Delete(userToBeDeleted);
                    if(Globals.ActiveUser.UserType == Domain.UserType.SystemAdministrator)
                    {
                        return new SystemAdministratorView();
                    }
                    return new LoginView();
                case ConsoleKey.N:
                    return this;
            }
            return this;
        }
    }

}
