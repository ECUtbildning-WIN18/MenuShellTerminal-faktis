using System;
using System.Threading;
using Domain;
using Services;
using Globals = Services.Globals;

namespace MenuShellTerminal.Views
{
    class ExpenseView : View
    {
        public override View ViewIt()
        {
            Console.Clear();
            Console.Title = "Customer";
            Console.WriteLine($"-----{Globals.ActiveUser.UserName}-----");
            Console.WriteLine("Item Name:");
            var expenseName = Console.ReadLine();
            Console.WriteLine("Price<SEK>:");
            if(!decimal.TryParse(Console.ReadLine(), out var expensePrice))
            {
                Console.WriteLine("Please write in decimal numbers only");
                Thread.Sleep(500);
                return this;
            }
            
            
            Console.WriteLine("Category:");
            var expenseCategory = Console.ReadLine();
            Console.WriteLine("(S)ave (H)ome (L)og Out");
            var key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.S:
                    CreateExpense.Add(expenseName,expensePrice,expenseCategory, Globals.ActiveUser.Id);
                    return new CustomerView();
                case ConsoleKey.H:
                    return new CustomerView();
                case ConsoleKey.L:
                    return new LoginView();
            }
            return this;
        }
    }
    
}

