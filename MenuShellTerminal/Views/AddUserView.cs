using System;
using System.Threading;
using Services;

namespace MenuShellTerminal.Views
{
    class AddUserView : View
    {
        public override View ViewIt()
        {
            Console.Clear();
            ViewHandler.CurrentView = this;
            Console.Title = "Add User";
            foreach (string screenString in ViewHandler.AddUserScreen())
                Console.WriteLine(screenString);
            Console.SetCursorPosition(10, 1);
            var userName = Console.ReadLine();
            Console.SetCursorPosition(10, 2);
            var passWord = Console.ReadLine();
            Console.SetCursorPosition(10, 3);
            var userType = Console.ReadLine();
            Console.WriteLine("Is this correct? (Y)es or (N)o !!! \n" +
                "(Esc) to go back to Admin View");
            var key = Console.ReadKey();
            Console.Clear();
            
            var message = CreateUser.CreateController(
                key.Key, 
                userName, passWord, userType);
            if(message != "SystemAdministrator" && message != "AgainMyself")
            {
                Console.WriteLine(message);
                Thread.Sleep(2000);                
            }
            return ViewHandler.ChangeView(message);
        }
    }
}
