using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Validations.CustomValidations;

namespace Validations.Models
{
    
    public class User
    {
    
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please enter Namw")]
        public string UserName { get; set; }

        [Display(Name = "User Email")]
        [Required,EmailAddress]
        public string UserEmail { get; set; }

        [Display(Name = "Date of Joining")] 
     
        public Nullable<System.DateTime> DOJ { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        [MinLength(6), MaxLength(10)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        [MinLength(6), MaxLength(10)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword  { get; set; }

        [DateRange(ErrorMessage = "Birth Date must be less than to Today's Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth
        {
            get;
            set;
        }
    }
}