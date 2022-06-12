using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMeProject.CustomFilters;
using QualifyMeProject.ViewModels;
using QualifyMeProject.ServiceLayer;


namespace QualifyMeProject.Controllers
{
    public class AccountController : Controller
    {
        IUsersService us;
        ICompanyUsersService cs;

        public AccountController(IUsersService us, ICompanyUsersService cs)
        {
            this.us = us;
            this.cs = cs;
        }

        public ActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                int uid = this.us.InsertUser(rvm);
                Session["CurrentUserID"] = uid;
                Session["CurrentID"] = rvm.ID;
                Session["CurrentUserName"] = rvm.Name;
                Session["CurrentUserEmail"] = rvm.Email;
                Session["CurrentUserPassword"] = rvm.Password;
                Session["CurrentUserIsAdmin"] = false;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View();
            }

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

        public ActionResult Profile()
        {
            UserViewModel uvm = new UserViewModel();
            return View();
        }

     

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

       
    }
}