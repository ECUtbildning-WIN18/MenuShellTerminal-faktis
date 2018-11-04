namespace Domain
{
    public class SystemAdministrator : User
    {
       
        public SystemAdministrator(string userName, string password) : base(userName, password, UserType.SystemAdministrator)
        {
            
        }
    }
}
