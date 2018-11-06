namespace Domain
{
    public class Customer : User
    {
       
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string SocialSecurityNumber { get; private set; }
        public Customer(string userName, string password, string firstName, string lastName, string socialSecurityNumber) : base(userName, password, UserType.Customer)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
        }
    }
}
