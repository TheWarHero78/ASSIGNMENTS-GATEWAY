using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCoreAssignment.Models
{
    public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }       
        public DateTime? LastLogin { get; set; }        
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

   
    }

}
