using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMeProject.ServiceLayer;

namespace QualifyMeProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private IUsersService us;

        public HomeController(IUsersService us)
        {
            this.us = us;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}