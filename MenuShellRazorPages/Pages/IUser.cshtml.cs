namespace MenuShellRazorPages.Pages
{
  public interface IUser
  {
    //public enum AccountType; { Customer, Receptionist, SystemAdministrator};
    //public AccountType UserAccountType { get; set; }
    //public string Username { get; set; }
    void Initialize(string username, string accountType);
    void OnGet();
  }
}
