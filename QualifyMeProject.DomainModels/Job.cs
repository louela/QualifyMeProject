using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualifyMeProject.DomainModels
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobID { get; set; }
        public int CompanyID { get; set; }
        public int CourseID { get; set; }
      
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }

        [ForeignKey("CompanyID")]
        public virtual CompanyUser CompanyUser { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }


    }
}
