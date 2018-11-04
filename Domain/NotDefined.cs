namespace Domain
{
    class NotDefined : User
    {
        public NotDefined(string userName = "NotDefined", string password = "NotDefined") : base(userName, password, UserType.NotDefined) { }
    }
}
