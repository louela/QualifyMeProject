using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMeProject.ServiceLayer;
using QualifyMeProject.ViewModels;

namespace QualifyMeProject.Areas.Admin.Controllers
{
    public class CoursesController : Controller
    {
        private ICoursesService cos;
        public CoursesController(ICoursesService cos)
        {
            this.cos = cos;
        }
        // GET: Admin/Courses
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCourse()
        {
            AddCourseViewModel acm = new AddCourseViewModel();
            return View(acm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(AddCourseViewModel acm)
        {
            if (ModelState.IsValid) 
            {
                int cid = this.cos.InsertCourse(acm);
                Session["CurrentCourseID"] = cid;
                Session["CurrentCourseDepartment"] = acm.CourseDepartment;
                Session["CurrentCourseSpecification"] = acm.CourseSpecification;
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View();
            }

        }

        public ActionResult ViewCourse(string CourseSpecification)
        {
            List<CourseViewModel> cvm = this.cos.GetCoursesBySpecification(CourseSpecification).Take(10).ToList();
            return View(cvm);
        }
    }
}