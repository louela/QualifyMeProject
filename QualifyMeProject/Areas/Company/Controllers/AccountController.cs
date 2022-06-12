using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMeProject.CustomFilters;
using QualifyMeProject.ServiceLayer;
using QualifyMeProject.ViewModels;

namespace QualifyMeProject.Areas.Company.Controllers
{
    public class AccountController : Controller
    {
        // GET: Company/Account
        ICompanyUsersService cs;

        public AccountController(ICompanyUsersService cs)
        {
            this.cs = cs;
        }
        public ActionResult Login()
        {
            CompanyLoginViewModel clm = new CompanyLoginViewModel();
            return View(clm);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CompanyLoginViewModel clm)
        {
            if (ModelState.IsValid)
            {
                CompanyUserViewModel cvm = this.cs.GetCompanyUsersByEmailAndPassword(clm.CompanyEmail, clm.CompanyPassword);
                if (cvm != null)
                {
                    Session["CurrentCompanyID"] = cvm.CompanyID;
                    Session["CurrentCompanyName"] = cvm.CompanyName;
                    Session["CurrentCompanyEmail"] = cvm.CompanyEmail;
                    Session["CurrentCompanyPassword"] = cvm.CompanyPasswordHash;
                    Session["CurrentCompanyMobile"] = cvm.CompanyMobile;
                    Session["CurrentCompanyAddress"] = cvm.CompanyAddress;
                    Session["CurrentCompanyDescription"] = cvm.CompanyDescription;
                    Session["CurrentCompanyIsAdmin"] = cvm.IsAdmin;
                    if (cvm.IsAdmin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });

                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "Company" });
                    }
                }
                else
                {
                    ModelState.AddModelError("x", "Invalid Email / Password");
                    return View(clm);

                }
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View(clm);
            }

               
        }

        public ActionResult Profile()
        {
            CompanyUserViewModel cvm = new CompanyUserViewModel();
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home",new { area = "Company" });
        }


        [CompanyUserAuthorizationFilter]
        public ActionResult EditCompanyProfile()
        {
            int cid = Convert.ToInt32(Session["CurrentCompanyID"]);
            CompanyUserViewModel cvm = this.cs.GetCompanyUsersByCompanyID(cid);
            EditCompanyUserDetailsViewModel ecdvm = new EditCompanyUserDetailsViewModel() { CompanyName = cvm.CompanyName, CompanyEmail = cvm.CompanyEmail, CompanyMobile = cvm.CompanyMobile, CompanyAddress = cvm.CompanyAddress, CompanyDescription = cvm.CompanyDescription, CompanyID = cvm.CompanyID };
            return View(ecdvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [CompanyUserAuthorizationFilter]
        public ActionResult EditCompanyProfile(EditCompanyUserDetailsViewModel ecdvm)
        {
            if (ModelState.IsValid)
            {
                ecdvm.CompanyID = Convert.ToInt32(Session["CurrentCompanyID"]);
                this.cs.UpdateCompanyUserDetails(ecdvm);
                Session["CurrentCompanyName"] = ecdvm.CompanyName;
                return RedirectToAction("Index", "Home", new { area = "Company" });
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View(ecdvm);
            }
        }
    }
}