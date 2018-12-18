using Services;
using System;
using System.Threading;

namespace MenuShellTerminal.Views
{
    public class LoginView : View
    {
        private bool _xOn = false;
        private bool _yOn = false;
        private string _userName = "False";
        private string _password = "False";
        private int _xPos = 0;
        private int _yPos = 0;

        private void Init()
        {
            _xOn = false;
            _yOn = false;
            _userName = "False";
            _password = "False";
            _xPos = 0;
            _yPos = 0;

        }
        public override View ViewIt()
        {
            Console.Clear();
            ViewHandler.CurrentView = this;
            Console.Title = "Login";
            Input();
            var key = Console.ReadKey().Key;
            
            var message = (Login.LoginController(key, _userName, _password));
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
                if (_xOn && _yOn)
                {
                    _yPos = int.Parse(screenString);
                    Console.SetCursorPosition(_xPos, _yPos);
                    if (_userName == "False")
                        _userName = Console.ReadLine();
                    else if (_password == "False")
                        _password = Console.ReadLine();
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
