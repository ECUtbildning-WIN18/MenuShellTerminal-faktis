using Domain;
using Services;
using System;
using System.Threading;

namespace MenuShellTerminal.Views
{
    public class LoginView : View
    {
        public override View ViewIt()
        {

            Console.Clear();
            ViewHandler.CurrentView = this;
            foreach(string screenString in ViewHandler.MenuScreen())
                Console.WriteLine(screenString);
            Console.SetCursorPosition(10, 1);
            var userName = Console.ReadLine();
            Console.SetCursorPosition(10, 2);
            var passWord = Console.ReadLine();
            Console.WriteLine("Is this correct? (Y)es or (N)o !!!");
            var key = Console.ReadKey().Key;
            var message = (Login.LoginController(key, userName, passWord));
            if(message != "SystemAdministrator" && message != "Customer" )
            {
                Console.WriteLine(message);
                Thread.Sleep(2000);
            }
            return ViewHandler.ChangeView(message);


        }
    }
}
