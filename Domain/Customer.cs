using System.Collections.Generic;

namespace Domain
{
    public class Customer : User
    {
       
        //public List<Expense> Expenses { get; set; }
//        public string LastName { get; private set; }
//        public string SocialSecurityNumber { get; private set; }
        public Customer(string userName, string password) : base(userName, password, UserType.Customer)
        {
        }

//        public void AddExpense(string itemName, decimal itemPrice, string itemType)
//        {
//            Expenses.Add(new Expense(itemName,itemPrice, itemType));
//        }
    }
}
