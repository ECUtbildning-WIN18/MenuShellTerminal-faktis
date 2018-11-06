using Services;
using System;
using System.Threading;

namespace MenuShellTerminal.Views
{
    public class LoginView : View
    {
        private bool xOn = false;
        private bool yOn = false;
        private string userName = "False";
        private string password = "False";
        private int xPos = 0;
        private int yPos = 0;
        
        public void Init()
        {
            xOn = false;
            yOn = false;
            userName = "False";
            password = "False";
            xPos = 0;
            yPos = 0;

        }
        public override View ViewIt()
        {
            Console.Clear();
            ViewHandler.CurrentView = this;
            Console.Title = "Login";
            Input();
            var key = Console.ReadKey().Key;
            
            var message = (Login.LoginController(key, userName, password));
            if (message != "SystemAdministrator" && message != "Customer" && message != "AgainMyself")
            {
                Console.WriteLine(message);
                Thread.Sleep(2000);
            }
            Init();
            return ViewHandler.ChangeView(message);



        }
        private void Input()
        {
            foreach (string screenString in ViewHandler.MenuScreen())
            {
                if (xOn && yOn)
                {
                    yPos = int.Parse(screenString);
                    Console.SetCursorPosition(xPos, yPos);
                    if (userName == "False")
                        userName = Console.ReadLine();
                    else if (password == "False")
                        password = Console.ReadLine();
                    xOn = false;
                    yOn = false;

                }
                else if (xOn && !yOn)
                {
                    xPos = int.Parse(screenString);
                    yOn = true;
                }
                else if (screenString == "Input")
                    xOn = true;
                else
                    Console.WriteLine(screenString);
            }
        }
    }
}
