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
        // GET: Company/Home
        private ICoursesService cos;
        public HomeController( ICoursesService cos)
        {
           
            this.cos = cos;

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Courses()
        {

            List<CourseViewModel> cvm = this.cos.GetCourses().Take(10).ToList();
            return View(cvm);
        }
    }
}