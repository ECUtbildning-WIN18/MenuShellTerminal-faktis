using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public List<string> AboutMessageList { get; set; } = ViewHandler.AddUserScreen();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            ViewBag.Message = "AddUser";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}