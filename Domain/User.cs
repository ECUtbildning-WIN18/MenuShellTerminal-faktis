using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class User : IUser
    {
        public string UserName { get; private set; }      
        public UserType UserType { get; private set; }
        private string passWord;
        
        public User( string userName , string passWord , UserType userType)
        {
            Init( userName , passWord , userType);
        }

        public void Init( string userName, string passWord, UserType userType)
        {
            UserName = userName;
            this.passWord = passWord;
            UserType = userType;
        }

        public bool PassWordPass( string passWord )
        {
            return this.passWord == passWord;
        }
    }
}
