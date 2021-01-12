using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products_AarshModi.Models
{
    public class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            this.Product = new HashSet<Product>();
        }

        public string CategoryID { get; set; }
        public string CategoryName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> tblProducts { get; set; }
        public HashSet<Product> Product { get; private set; }
    }
}
