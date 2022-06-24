using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMeProject.ServiceLayer;
using QualifyMeProject.ViewModels;

namespace QualifyMeProject.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        private IUsersService us;
        private ICompanyUsersService cs;
        private ICoursesService cos;
        private IDepartmentsService ds;

        public HomeController(IUsersService us, ICompanyUsersService cs, ICoursesService cos,IDepartmentsService ds)
        {
            this.us = us;
            this.cs = cs;
            this.cos = cos;
           this.ds = ds;
        }
     
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            LoginViewModel lvm = new LoginViewModel();
            return View(lvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                UserViewModel uvm = this.us.GetUsersByEmailAndPassword(lvm.Email, lvm.Password);
                if (uvm != null)
                {
                    Session["CurrentUserID"] = uvm.UserID;
                    Session["CurrentStudentID"] = uvm.ID;
                    Session["CurrentUserName"] = uvm.Name;
                    Session["CurrentUserEmail"] = uvm.Email;
                    Session["CurrentUserMobile"] = uvm.Mobile;
                    Session["CurrentUserPassword"] = uvm.Password;
                    Session["CurrentUserIsAdmin"] = uvm.IsAdmin;


                    if (uvm.IsAdmin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });


                    }
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("x", "Invalid Email / Password");
                    return View(lvm);
                }

            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View(lvm);
            }

        }

        public ActionResult Companies()
        {

            List<CompanyUserViewModel> cvm = this.cs.GetCompanyUsers().Take(10).ToList();
            return View(cvm);

        }


        public ActionResult Students()
        {

            List<UserViewModel> uvm = this.us.GetUsers().Take(10).ToList();
            return View(uvm);

        }

        public ActionResult Courses()
        {

            List<CourseViewModel> cvm = this.cos.GetCourses().Take(10).ToList();
            return View(cvm);

        }
        public ActionResult Departments()
        {

            List<DepartmentViewModel> dvm = this.ds.GetDepartments().Take(10).ToList();
            return View(dvm);

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home", new { area = "" });
        }


    }
}


