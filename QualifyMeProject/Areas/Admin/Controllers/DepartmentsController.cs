using QualifyMeProject.ServiceLayer;
using QualifyMeProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QualifyMeProject.Areas.Admin.Controllers
{
    public class DepartmentsController : Controller
    {
        private IDepartmentsService ds;

        public DepartmentsController(IDepartmentsService ds)
        {
            this.ds = ds;
        }
        // GET: Admin/Departments
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddDepartment()
        {
            AddDepartmentViewModel adm = new AddDepartmentViewModel();
            return View(adm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDepartment(AddDepartmentViewModel adm)
        {
            if (ModelState.IsValid)
            {
                int cid = this.ds.AddDepartment(adm);
                Session["CurrentDeptID"] = cid;
                Session["CurrentDepartmentName"] = adm.DepartmentName;

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