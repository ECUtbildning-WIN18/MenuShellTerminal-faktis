using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using MenuShellRazorPages.Pages

namespace MenuShellRazorPages.Pages
{
  public class CustomerModel : PageModel
  {
    //private AccountType accountType;
    //public AccountType AccountType { get; set; }
    public List <AnimalModel> AnimalCompanions { get; set; }
    public string Username { get; set; }
    public string AccountType {get; set; }
    public CustomerModel()
    {
      Initialize("username", "Customer");
    }

    public void Initialize(string username, string accountType, List <AnimalModel> animalCompanions = null)
    {
      Username = username;
      AccountType = accountType;
      if(animalCompanions != null)
      {
        AnimalCompanions = new List <AnimalModel>();
      }
      else
      {
        AnimalCompanions = animalCompanions;
      }
      
    }
    public void OnGet()
    {
      
    }
  }
}
