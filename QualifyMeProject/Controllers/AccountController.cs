﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QualifyMeProject.ViewModels;
using QualifyMeProject.ServiceLayer;

namespace QualifyMeProject.Controllers
{
    public class AccountController : Controller
    {
        private IUsersService us;

        public AccountController(IUsersService us) 
        {
            this.us = us;
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
                Session["CurrentUserName"] = rvm.Name;
                Session["CurrentUserEmail"] = rvm.Email;
                Session["CurrentUserPassword"] = rvm.Password;
                Session["CurrentUserIsAdmin"] = false;
                Session["CurrentUserIsCompany"] = false;
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