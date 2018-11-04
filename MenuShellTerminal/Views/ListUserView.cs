using Services;
using System;
using System.Threading;


namespace MenuShellTerminal.Views
{
    public class ListUserView : View
    {
        public override View ViewIt()
        {
            Console.Clear();
            var iterator = 1;
            if (Globals.SearchResults.Count != 0)
            {
                foreach (string user in Globals.SearchResults)
                {
                    Console.WriteLine($"{iterator++}: {user}");

                }
                Console.WriteLine("Index of User to view: ");
                int indexOfUser = -1;
                if (int.TryParse(Console.ReadLine(), out indexOfUser))
                {
                    Globals.UserToView = SearchAndFind.GetUserWithUserName(Globals.SearchResults[indexOfUser - 1]);
                    return new UserInformativeView();
                }
            }
            else
            {
                Console.WriteLine("No user found");
                Thread.Sleep(2000);
            }
            
            return new SystemAdministratorView();
        }
    }
}
