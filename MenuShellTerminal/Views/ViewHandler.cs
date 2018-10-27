using MenuShellTerminal.Views;
using System.Collections.Generic;
namespace MenuShellTerminal
{
    public static class ViewHandler
    {
        public static List<string> MenuScreen()
        {
            return  new List<string>()
            {
                "Login" ,
                "UserName:" ,
                "Password:"
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
                "-----Add User-----" ,
                "Userame:" ,
                "Password:" ,
                "UserType:" ,
                "Input" ,
                "10" ,
                "1" ,
                "Input" ,
                "10" ,
                "2" ,
                "Input" ,
                "10" ,
                "3" ,
                "Is this correct? (Y)es or (N)o !!! \n" +
                "(Esc) to go back to Admin View"
            };
        }
        public static View CurrentView = null;
        public static View ChangeView(string message)
        {
            switch (message)
            {
                case "SystemAdministrator":
                    return new SystemAdministratorView();
                case "Customer":
                    return new CustomerView();
                case "AddUser":
                    return new AddUserView();
                case "SearchUser":
                    return new SearchUserView();
                case "LogOut":
                    return new LoginView();
                case "AgainMyself":
                    return CurrentView;
                default:
                    return CurrentView;
            }
        }
    }
}
