using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products_AarshModi.Models
{
  
    public  class User
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PassportImage { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Phone { get; set; }
    }
}