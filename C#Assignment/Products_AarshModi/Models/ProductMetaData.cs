using Products_AarshModi.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Products_AarshModi.Models
{
    public class ProductMetaData
    {
        [Display(Name = "Product ID")]
        [Key]         
        public string ProductID { get; set;}

        [Display(Name = "Product Name")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "{0} is too long.")]
        [Required(ErrorMessage = "Please enter {0}")]
        public string ProductName { get; set; }

        [Display(Name = "Product Category")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "{0} is too long.")]
        [Required(ErrorMessage = "Please enter {0}")]
        public string Category { get; set; }

        [Display(Name = "Product Price")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Please enter {0}")]
        public decimal Price { get; set; }

        [Display(Name = "Product Quantity")]        
        [Required(ErrorMessage = "Please enter {0}")]
        public int Quantity { get; set; }

        [Display(Name = "Product Short Description")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter {0}")]
        public string ShortDescription { get; set; }

        [Display(Name = "Product Long Description")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter {0}")]
        public string LongDescription { get; set; }

        [Display(Name = "Product Small Image:")]
        public string SmallImagePath { get; set; }
        [Required(ErrorMessage = "Please enter {0}")]
        [FileType("png,jpg,jpeg")]
        public HttpPostedFileBase SmallImage { get; set; }

        [Display(Name = "Product Large Image:")]
        public string LargeImagePath { get; set; }
        [Required(ErrorMessage = "Please enter {0}")]
        [FileType("png,jpg,jpeg")]
        public HttpPostedFileBase[] LargeImage { get; set; }
       
    }
   
}