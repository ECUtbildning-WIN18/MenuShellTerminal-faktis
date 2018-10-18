//using Domain;
using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuShellTerminal.Views
{
    public class SearchUserView : View
    {
        public override View ViewIt()
        {
            Console.Clear();
            Console.WriteLine("Search by username:\n");
            //var searchFor = Console.ReadLine();
            var snf = new SearchAndFind();
            var searchResults = snf.StringOfUserNamesIncludingString(Console.ReadLine());
            Console.Clear();
            var iterator = 1;
            foreach(string user in searchResults)
            {
                Console.WriteLine($"{iterator++}: {user}");

            }
            Console.WriteLine("Index of User to view: ");

            int indexOfUser = -1;// = int.Parse(Console.ReadLine());
            //if(isDigit(Console.ReadLine())
            if (int.TryParse(Console.ReadLine(), out indexOfUser))
            {
                Globals.UserToView = snf.UserWithUserName(searchResults[indexOfUser - 1]);
                return new UserInformativeView();
            }
            

            return new SystemAdministratorView();
        }
    }
}
