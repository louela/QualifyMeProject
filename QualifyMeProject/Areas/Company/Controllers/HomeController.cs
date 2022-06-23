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
        private IDepartmentsService dos;
        public HomeController( ICoursesService cos,IDepartmentsService dos)
        {
           
            this.cos = cos;
            this.dos = dos;

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

        public ActionResult Departments()
        {
            List<DepartmentViewModel> dvm = this.dos.GetDepartments().Take(10).ToList();
            return View(dvm);
        }


    }
}