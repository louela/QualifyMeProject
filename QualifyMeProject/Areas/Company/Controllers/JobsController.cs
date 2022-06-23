using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QualifyMeProject.Areas.Company.Controllers
{
    public class JobsController : Controller
    {
        // GET: Company/Jobs
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JobListings()
        {

            return View();
        }
    }
}