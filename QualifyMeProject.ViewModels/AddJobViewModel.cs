using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMeProject.ViewModels
{
    public class AddJobViewModel
    {

        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string JobDescription { get; set; }

        [Required]
        public bool IsActive { get; set; }



    }
}
