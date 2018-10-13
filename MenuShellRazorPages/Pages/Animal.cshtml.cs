using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MenuShellRazorPages.Pages
{
  public class AnimalModel : PageModel
  {
    public string AnimalName { get; set; }
    public AnimalModel()
    {
      AnimalName = "animalName";

    }
    public void OnGet()
    {

    }
  }
}
