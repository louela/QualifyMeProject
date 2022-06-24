﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMeProject.DomainModels
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }
       
        public int DeptID { get; set; }
      
        public string CourseName { get; set; }


        [ForeignKey("DeptID")]
        public virtual Department Department { get; set; }

    }
}
