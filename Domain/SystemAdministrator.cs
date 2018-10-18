//using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SystemAdministrator : User
    {
        public SystemAdministrator(string userName, string passWord) : base(userName, passWord, UserType.SystemAdministrator) { }
    }
}
