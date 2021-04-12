using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreAssignment.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(15), MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MaxLength(15), MinLength(3)]
        public string Department { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public Boolean IsManager { get; set; }
        public long Manager { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }


    }
}
