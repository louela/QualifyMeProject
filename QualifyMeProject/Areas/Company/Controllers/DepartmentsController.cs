using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMeProject.ServiceLayer;
using QualifyMeProject.ViewModels;

namespace QualifyMeProject.Areas.Company.Controllers
{
    public class DepartmentsController : Controller
    {
        private IDepartmentsService ds;

        private ICoursesService cs;

        public DepartmentsController(IDepartmentsService ds, ICoursesService cs)
        {
            this.ds = ds;   
            this.cs = cs;
        }
        // GET: Company/Departments
       

        public ActionResult View(int id)
        {
            
            CourseViewModel cvm = this.cs.GetCoursesByDepartmentID(id);
            return View(cvm);
        }

        public ActionResult AddDepartment()
        {
            AddDepartmentViewModel adm= new AddDepartmentViewModel();
            return View(adm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDepartment(AddDepartmentViewModel adm)
        {
            if (ModelState.IsValid)
            {
                int did = this.ds.AddDepartment(adm);
                Session["CurrentDeptID"] = did;
                Session["CurrentDepartmentName"] = adm.DepartmentName;
              

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return RedirectToAction("Departments", "Home");
            }
        }

           
    }
}




