using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualifyMeProject.ViewModels
{
    public class LoginViewModel
    {
        [Required]
<<<<<<< HEAD
        public string Email;
=======
        public string Email { get; set; }
>>>>>>> main

        [Required] 
        public string Password { get; set; }
    }
}
