using System;

namespace Domain
{
    public class Expense
    {
        //public int Id { get; private set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemType { get; set; }
        public int UserId { get; set; }
        public DateTime DateAdded { get; set; }

        public Expense(string itemName, decimal itemPrice, string itemType, int userId)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemType = itemType;
            UserId = userId;
            DateAdded = DateTime.Now;
        }

        
    }
}