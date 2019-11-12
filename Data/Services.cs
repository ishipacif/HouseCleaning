using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseCleanersApi.Data
{
    public partial class Services
    {
        public Services()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int ServiceId { get; set; }
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public string ServiceDescription { get; set; }
        [Required]
        public string ServiceCommission { get; set; }
        public int? CategoryId1 { get; set; }

        public virtual Categories CategoryId1Navigation { get; set; }
        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
