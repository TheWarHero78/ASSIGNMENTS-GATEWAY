using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            this.Bookings = new HashSet<Booking>();
        }

        public long ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Nullable<decimal> Price { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Updated_Date { get; set; }
        public string Updated_By { get; set; }
        public Nullable<long> Hotel_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
