using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseCleanersApi.Data
{
    public partial class Status
    {
        public Status()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int StatusId { get; set; }
        [Required]
        public string StatusName { get; set; }
        [Required]
        public string StatusDescription { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
