using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMeProject.ServiceLayer;
using QualifyMeProject.ViewModels;

namespace QualifyMeProject.Areas.Company.Controllers
{
    public class AccountController : Controller
    {
        ICompaniesService cs;

        public AccountController(ICompaniesService cs)
        {
            this.cs = cs;
        }
        // GET: Company/Account
      
        public ActionResult Login()
        {
            LoginCompanyViewModel lcvm = new LoginCompanyViewModel();
            return View(lcvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompanyLogin(LoginCompanyViewModel lcvm)
        {
            if (ModelState.IsValid)
            {
                CompanyUserViewModel cvm = this.cs.GetCompaniesByEmailAndPassword(lcvm.CompanyEmail, lcvm.CompanyPassword);
                if (cvm != null)
                {
                    Session["CurrentCompanyID"] = cvm.CompanyID;
                    Session["CurrentCompanyName"] = cvm.CompanyName;
                    Session["CurrentCompanyEmail"] = cvm.CompanyEmail;
                    Session["CurrentCompanyPassword"] = cvm.CompanyPasswordHash;
                    Session["CurrentUserIsAdmin"] = cvm.IsAdmin;

                    if (cvm.IsAdmin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });

                    }

                    else
                        return RedirectToAction("Index", "Home", new { area = "Company" });
                }
                else
                {
                    ModelState.AddModelError("x", "Invalid Email / Password");
                    return View(lcvm);
                }
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View(lcvm);
            }

        }
    }
}