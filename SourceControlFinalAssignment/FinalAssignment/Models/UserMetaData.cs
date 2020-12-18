using FinalAssignment.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalAssignment.Models
{
    public class UserMetaData
    {
        [ScaffoldColumn(false)]
        [Key]
        public int UserID { get; set; }
        //Server-side validations with validator attributes: 
        //3.1.1) Range
        [Display(Name = "User Age:")]
        [Range(1, 100, ErrorMessage = "Invalid {0}")]
        public int Age { get; set; }


        //3.1.2) Regular Expression

        [Display(Name = "User First Name")]
        [MaxWords(1)]
        [RegularExpression(@"^([a-zA-Z0-9 \.\&\'\-]+)$", ErrorMessage = "Invalid {0}")]
        public string FirstName { get; set; }


        //3.1.3) Required	
        //3.1.4) String Length
        [Display(Name = "User Last Name")]
        [StringLength(20, ErrorMessage = "{0} is too long.")]
        [Required(ErrorMessage = "Please enter {0}")]
        public string LastName { get; set; }

        //
        [Display(Name = "User Email")]
        [Required, EmailAddress]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} is Required")]
        [MinLength(6), MaxLength(10)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        [MinLength(6), MaxLength(10)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Passport Size Image:")]
        public string ImagePath { get; set; }
        //3.1.5) File Extension   
        [FileType("png,jpg,jpeg")]
        public HttpPostedFileBase PassportImage { get; set; }

        //3.1.6) Custom Validation 
        [DateRange(ErrorMessage = "Joining Date must be less than to Today's Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Joining Date")]
        public DateTime DateOfJoining
        {
            get;
            set;
        }


        //3.1.7) Phone
       
        [Display(Name = "Phone No:")]
        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
    }




}

