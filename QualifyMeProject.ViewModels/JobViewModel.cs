using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMeProject.ViewModels
{
    public class JobViewModel
    {
        public int JobID { get; set; }
        public int CompanyID { get; set; }
        public int CourseID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }

    }
}
