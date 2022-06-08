using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMeProject.ServiceLayer;
using QualifyMeProject.ViewModels;

namespace QualifyMeProject.Areas.Company.Controllers
{
    public class HomeController : Controller
    {
        ICompaniesService cs;

        public HomeController(ICompaniesService cs)
        {
            this.cs = cs;
        }
        public ActionResult Index()
        {
            return View();
        }
      

        

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}