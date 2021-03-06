using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMeProject.ViewModels
{
    public class RegisterViewModel
    {   
        [Required]
        public string ID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        [Required]
        public string Mobile { get; set; }
    }
}
