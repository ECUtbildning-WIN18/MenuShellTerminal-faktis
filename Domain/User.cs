using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
//using System.Xml;
using System.Xml.Linq;

namespace Domain
{
    public abstract class User : IUser
    {
        public string UserName { get; private set; }      
        public UserType UserType { get; private set; }
        private string passWord;
        public string SaltHashPassWord { get; private set; }
        
        public User( string userName , string passWord , UserType userType)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(passWord, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            SaltHashPassWord = Convert.ToBase64String(hashBytes);
            Init( userName , SaltHashPassWord, userType);
        }

        public void Init( string userName, string passWord, UserType userType)
        {
            UserName = userName;
            this.passWord = passWord;
            UserType = userType;
        }

        public bool PassWordPass( string passWord )
        {
            //var reader = Database.UsersXML;
            //var root = reader.Root;
            //foreach (var element in root.Elements())
            //{
                //if (element.Element("Name").Value == UserName)
                //{
                //var elementUser = element;
                string savedPasswordHash = this.passWord;//elementUser.Element("PassWord").Value;
                    /* Extract the bytes */
                    byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
                    /* Get the salt */
                    byte[] salt = new byte[16];
                    Array.Copy(hashBytes, 0, salt, 0, 16);
                    /* Compute the hash on the password the user entered */
                    var pbkdf2 = new Rfc2898DeriveBytes(passWord, salt, 10000);
                    byte[] hash = pbkdf2.GetBytes(20);
                    /* Compare the results */
                    for (int i = 0; i < 20; i++)


                        if (hashBytes[i + 16] != hash[i])
                            return false;
                    return true;
                //}
            //}

            //return false;
        }
    }
}
