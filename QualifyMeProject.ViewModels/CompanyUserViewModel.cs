using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMeProject.ViewModels
{
    public class CompanyUserViewModel
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPasswordHash { get; set; }
        public string CompanyMobile { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyDescription { get; set; }
        public bool IsAdmin { get; set; }
    }
}
