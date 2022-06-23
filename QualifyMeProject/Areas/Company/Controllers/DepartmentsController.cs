using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QualifyMeProject.Areas.Company.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Company/Departments
        public ActionResult Index()
        {
            return View();
        }
    }
}