using System;
using System.Threading;
using Services;

namespace MenuShellTerminal.Views
{
    class AddUserView : View
    {
        private bool xOn = false;
        private bool yOn = false;
        private int xPos = 0;
        private int yPos = 0;

        private string password = "False";
        public string UserType { get; private set; } = "False";
        public string UserName { get; private set; } = "False";

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
                UserName, password, UserType);
            if(message != "SystemAdministrator" && message != "AgainMyself")
            {
                Console.WriteLine(message);
                Thread.Sleep(2000);                
            }
            UserName = "False";
            password = "False";
            UserType = "False";
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
                    if (UserName == "False")
                        UserName = Console.ReadLine();
                    else if (password == "False")
                        password = Console.ReadLine();
                    else if (UserType == "False")
                        UserType = Console.ReadLine();
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
