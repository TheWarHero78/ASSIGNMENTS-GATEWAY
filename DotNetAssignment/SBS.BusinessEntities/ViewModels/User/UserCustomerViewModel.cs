using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntities
{
    public class UserCustomerViewModel
    {

       
        [Key]
        public System.Guid ExternalID { get; set; }
        public long ID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string Mobile { get; set; }
        public string PhoneNo { get; set; }
       public long UserID { get; set; }
    }
}
