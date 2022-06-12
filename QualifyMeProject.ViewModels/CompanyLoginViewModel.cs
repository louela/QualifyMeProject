using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMeProject.ViewModels
{
    public class CompanyLoginViewModel
    {
        [Required]
        public string CompanyEmail { get; set; }

        [Required]
        public string CompanyPassword { get; set; }
    }
}

