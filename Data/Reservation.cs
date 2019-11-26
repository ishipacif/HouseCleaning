using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseCleanersApi.Data
{
    public partial class Reservation
    {
        public Reservation()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
        }

        public int ReservationId { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        [Required]
        public DateTime StartHour { get; set; }
        [Required]
        public DateTime EndHour { get; set; }
        public int? ProfessionalId { get; set; }
        public int? CustomerId { get; set; }
        public int? JobServiceId { get; set; }
        public int? StatusId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Service JobService { get; set; }
        public virtual Professional Professional { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
