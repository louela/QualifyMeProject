using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace QualifyMeProject.ViewModels
{
    public class EditCompanyDetailsViewModels
    {
        public int CompanyID { get; set; }

        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})")]
        public string CompanyEmail { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyMobile { get; set; }
        [Required]
        public string CompanyAddress { get; set; }
        [Required]
        public string CompanyDescription { get; set; }
    }
}
