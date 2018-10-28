
using System.Collections.Generic;
namespace WebApplication
{
    public static class ViewHandler
    {
        public static List<string> MenuScreen()
        {
            return  new List<string>()
            {
                "Login" ,
                "UserName:" ,
                "Password:",
                "Input" ,
                "10" ,
                "1" ,
                "Input" ,
                "10" ,
                "2" ,
                "Is this correct? (Y)es or (N)o !!!"
            };
        }
        public static List<string> AdminScreen()
        {
            return new List<string>()
            {
                "SystemAdministrator" ,
                "-----Options-----" ,
                "(A)dd User" ,
                "(S)earch User" ,
                "(L)og Out"
            };
        }
        public static List<string> AddUserScreen()
        {
            return new List<string>()
            {
                
                "Userame:" ,
                "Password:" ,
                "UserType:" ,
            };
        }
        
    }
}
