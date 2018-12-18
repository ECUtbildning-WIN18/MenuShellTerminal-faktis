using System;
using System.Threading;
using Services;

namespace MenuShellTerminal.Views
{
    internal class AddUserView : View
    {
        private bool _xOn = false;
        private bool _yOn = false;
        private int _xPos = 0;
        private int _yPos = 0;

        private string _password = "False";
        private string _userType  = "False";
        private string _userName  = "False";

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
                _userName, _password, _userType);
            if(message != "SystemAdministrator" && message != "AgainMyself")
            {
                Console.WriteLine(message);
                Thread.Sleep(2000);                
            }
            _userName = "False";
            _password = "False";
            _userType = "False";
            return ViewHandler.ChangeView(message);
        }

        private void Input()
        {
            foreach (var screenString in ViewHandler.AddUserScreen())
            {
                if (_xOn && _yOn)
                {
                    _yPos = int.Parse(screenString);
                    Console.SetCursorPosition(_xPos, _yPos);
                    if (_userName == "False")
                        _userName = Console.ReadLine();
                    else if (_password == "False")
                        _password = Console.ReadLine();
                    else if (_userType == "False")
                        _userType = Console.ReadLine();
                    _xOn = false;
                    _yOn = false;
                    
                }
                else if (_xOn && !_yOn)
                {
                    _xPos = int.Parse(screenString);
                    _yOn = true;
                }
                else if (screenString == "Input")
                    _xOn = true;
                else
                    Console.WriteLine(screenString);
            }
        }
    }
}
