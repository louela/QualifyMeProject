using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMeProject.ViewModels
{
    public class AddDepartmentViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string DepartmentName { get; set; }

        
    }
}
