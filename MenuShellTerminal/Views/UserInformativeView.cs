using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShellTerminal.Views
{
    public class UserInformativeView : View
    {
        public override View ViewIt()
        {
            Console.Clear();
            Console.WriteLine($"-----{Globals.UserToView.UserName}-----");
            Console.WriteLine("(E)dit or (D)elete");
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.E:
                    //edit view
                    break;
                case ConsoleKey.D:
                    return new DeleteUserView(Globals.UserToView.UserName);
            }
            return this;
        }
    }
}
