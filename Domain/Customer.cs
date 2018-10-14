using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Customer : User
    {
        public Customer(string userName, string passWord) : base(userName, passWord, UserType.Customer) { }
    }
}
