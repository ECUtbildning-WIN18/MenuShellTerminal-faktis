using System;
using System.Threading;
using Services;

namespace MenuShellTerminal.Views
{
    class AddUserView : View
    {
        private bool xOn = false;
        private bool yOn = false;
        private string userName = "False";
        private string password = "False";
        private string userType = "False";
        private int xPos = 0;
        private int yPos = 0;

        public override View ViewIt()
        {
            Console.Clear();
            ViewHandler.CurrentView = this;
            Console.Title = "Add User";
            Input();
            var key = Console.ReadKey();
            Console.Clear();
            var message = CreateUser.CreateController(
                key.Key, 
                userName, password, userType);
            if(message != "SystemAdministrator" && message != "AgainMyself")
            {
                Console.WriteLine(message);
                Thread.Sleep(2000);                
            }
            userName = "False";
            password = "False";
            userType = "False";
            return ViewHandler.ChangeView(message);
        }

        private void Input()
        {
            foreach (string screenString in ViewHandler.AddUserScreen())
            {
                if (xOn && yOn)
                {
                    yPos = int.Parse(screenString);
                    Console.SetCursorPosition(xPos, yPos);
                    if (userName == "False")
                        userName = Console.ReadLine();
                    else if (password == "False")
                        password = Console.ReadLine();
                    else if (userType == "False")
                        userType = Console.ReadLine();
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
