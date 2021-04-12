using System;
using System.ComponentModel.DataAnnotations;

namespace Emp.BusinessEntities.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        [StringLength(15)]
        public string Department { get; set; }
        [Required]

        [Range(100,100000)]
        public decimal Salary { get; set; }
        [Required]
        public Boolean IsManager { get; set; }
        public long Manager { get; set; }
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
