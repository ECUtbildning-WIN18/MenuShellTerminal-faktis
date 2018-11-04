using System;

namespace MenuShellTerminal.Views
{
    class SystemAdministratorView : View
    {
        public override View ViewIt()
        {
            Console.Clear();
            ViewHandler.CurrentView = this;
            Console.Title = "SystemAdministrator";
            foreach (string screenString in ViewHandler.AdminScreen())
                Console.WriteLine(screenString);
            var key = Console.ReadKey().Key;
            Console.Clear();
            return ChangeView(key);
        }

        private View ChangeView(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A:
                    return ViewHandler.ChangeView("AddUser");

                case ConsoleKey.S:
                    return ViewHandler.ChangeView("SearchUser");

                case ConsoleKey.L:
                    return ViewHandler.ChangeView("LogOut");
                default:
                    return ViewHandler.ChangeView("AgainMyself");
            }
        }
    }
}
