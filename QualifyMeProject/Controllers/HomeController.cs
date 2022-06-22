using QualifyMeProject.ViewModels;
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
        private ICompanyUsersService cs;
        private ICoursesService cos;

        public HomeController(IUsersService us, ICompanyUsersService cs, ICoursesService cos)
        {
            this.us = us;
            this.cs = cs;
            this.cos = cos;

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Courses()
        {

            List<CourseViewModel> cvm = this.cos.GetCourses().Take(10).ToList();
            return View(cvm);

        }

        public ActionResult Companies()
        {

            List<CompanyUserViewModel> cvm = this.cs.GetCompanyUsers().Take(10).ToList();
            return View(cvm);

        }


    }
}