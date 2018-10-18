using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class SearchAndFind
    {
        public List<string> StringOfUserNamesIncludingString(string searchCriteria)
        {
            List<string> searchResults = new List<string>();
            foreach (string userName in Database.UserNames)
            {
                var different = false;
                for (int i = 0; i < searchCriteria.Length; i++)
                {
                    if (userName.Length < i) break;

                    different = searchCriteria[i] != userName[i];

                    if (different) break;

                }
                if (!different) searchResults.Add(userName);
            }
            return searchResults;
        }
        public User UserWithUserName(string userName)
        {
            return Database.Users[userName];
        }
    }
}
