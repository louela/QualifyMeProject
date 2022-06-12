using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMeProject.DomainModels;
using QualifyMeProject.ServiceLayer;
using QualifyMeProject.ViewModels;


namespace QualifyMeProject.Areas.Admin.Controllers
{

    
    public class CompaniesController : Controller
    {
        // GET: Admin/Companies
        
        private ICompanyUsersService cs;
        public CompaniesController( ICompanyUsersService cs)
        {
            this.cs = cs;
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddCompany()
        {
            AddCompanyViewModel acm = new AddCompanyViewModel();
            return View(acm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCompany(AddCompanyViewModel acm)
        {
            if (ModelState.IsValid)
            {
                int cid = this.cs.InsertCompanyUser(acm);
                Session["CurrentCompanyID"] = cid;
                Session["CurrentCompanyName"] = acm.CompanyName;
                Session["CurrentCompanyEmail"] = acm.CompanyEmail;
                Session["CurrentCompanyPassword"] = acm.CompanyPassword;
                Session["CurrentCompanyAddress"] = acm.CompanyAddress;
                Session["CurrentCompanyDescription"] = acm.CompanyDescription;
                Session["CurrentCompanyIsAdmin"] = false;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View();
            }

        }

       


    }
}