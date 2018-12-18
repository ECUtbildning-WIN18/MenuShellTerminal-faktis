using Domain;
using Domain.Contexts;

namespace Services
{
    public static class CreateExpense
    {
        public static void Add(string itemName, decimal itemPrice, string itemType, int userId)
        {
            using (var db = new MenuShellContext())
            {
                var expense = new Expense(itemName, itemPrice, itemType, userId);
                db.Expense.Add(expense);
                db.SaveChanges();
            }
        }
    }
}