using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Models
{
    public partial class Services
    {
        public Services()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceCommission { get; set; }
        public int? CategoryId1 { get; set; }

        public virtual Categories CategoryId1Navigation { get; set; }
        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
