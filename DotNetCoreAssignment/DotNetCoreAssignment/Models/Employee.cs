using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetCoreAssignment.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public Boolean IsManager { get; set; }
        public long Manager { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        
    }
}
