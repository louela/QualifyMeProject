﻿using System;
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
        public int Email;

        [Required]
        public string Password;
    }
}