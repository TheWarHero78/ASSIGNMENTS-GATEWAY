using System;

namespace Emp.BusinessEntities.ViewModels
{
    public class EmployeeViewModel
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
