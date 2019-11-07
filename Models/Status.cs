using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Models
{
    public partial class Status
    {
        public Status()
        {
            Reservations = new HashSet<Reservations>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
