using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;



namespace QualifyMeProject.ViewModels
{
    public class EditCompanyPasswordViewModel
    {
    [Required]
    public int CompanyID { get; set; }
    [Required]
    public string CompanyEmail { get; set; }
    [Required]
    public string CompanyPassword { get; set; }
    [Required]
    [Compare("CompanyPassword")]
    public string CompanyConfirmPassword { get; set; }
    }
}
