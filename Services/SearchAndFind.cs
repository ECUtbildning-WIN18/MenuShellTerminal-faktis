using Domain;
using Domain.Contexts;
using System.Collections.Generic;

namespace Services
{
    public static class SearchAndFind
    {
        public static void GenerateListOfUserNames(string searchCriteria)
        {
            using (var context = new MenuShellContext())
            {
                Globals.SearchResults = new List<string>();
                foreach (var customer in context.Customer)
                {
                    var different = false;
                    for (int i = 0; i < searchCriteria.Length; i++)
                    {
                        if (customer.UserName.Length < i) break;

                        different = searchCriteria[i] != customer.UserName[i];

                        if (different) break;

                    }
                    if (!different) Globals.SearchResults.Add(customer.UserName);
                }
                foreach (var admin in context.Admin)
                {
                    var different = false;
                    for (int i = 0; i < searchCriteria.Length; i++)
                    {
                        if (admin.UserName.Length < i) break;

                        different = searchCriteria[i] != admin.UserName[i];

                        if (different) break;

                    }
                    if (!different) Globals.SearchResults.Add(admin.UserName);
                }
            }
        }

        public static User GetUserWithUserName(string username)
        {
            using (var context = new MenuShellContext())
            {
                foreach (var customer in context.Customer)
                {
                    if (customer.UserName == username) return customer;
                }
                foreach (var admin in context.Admin)
                {
                    if (admin.UserName == username) return admin;
                }
            }
            return null;
        }
    }
}
