using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Hotel
    {
      
        public long ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Contact_Number { get; set; }
        public string Contatct_Person { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime Created_Date { get; set; }
        public string Created_By { get; set; }
        public System.DateTime Updated_Date { get; set; }
        public string Updated_By { get; set; }



      
    }
}
