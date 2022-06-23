using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMeProject.ServiceLayer;
using QualifyMeProject.ViewModels;

namespace QualifyMeProject.Areas.Company.Controllers
{
    public class JobsController : Controller
    {
        // GET: Company/Jobs
        private IJobsService jos;
        public JobsController(IJobsService jos)
        {

            this.jos = jos;

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult JobListings()
        {
            List<JobViewModel> jvm = this.jos.GetJobs().Take(10).ToList();
            return View(jvm);
            
        }

        public ActionResult AddJob()
        {
            AddJobViewModel ajm = new AddJobViewModel();
            return View(ajm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddJob(AddJobViewModel ajm)
        {
            if (ModelState.IsValid)
            {
                int jid = this.jos.AddJobs(ajm);
                Session["CurrentJobID"] = jid;
                Session["CurrentJobTitle"] = ajm.JobTitle;
                Session["CurrentJobDescription"] = ajm.JobDescription;
                Session["CurrentJobStatus"] = ajm.IsActive;

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



