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
                db.Expense.Add(new Expense(itemName,itemPrice,itemType,userId));
                db.SaveChanges();
            }
        }
    }
}