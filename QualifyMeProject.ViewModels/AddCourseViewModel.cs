using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMeProject.ViewModels
{
    public class AddCourseViewModel
    {

        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string DepartmentName { get; set; }

        [RegularExpression(@"^[a-zA-Z ]*$")]
        [Required]
        public string CourseName { get; set; }
    }
}

