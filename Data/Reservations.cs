using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Data
{
    public partial class Reservations
    {
        public Reservations()
        {
            InvoiceLines = new HashSet<InvoiceLines>();
        }

        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        public int? ProfessionalId { get; set; }
        public int? CustomerId { get; set; }
        public int? JobServiceId { get; set; }
        public int? StatusId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Services JobService { get; set; }
        public virtual Professionals Professional { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<InvoiceLines> InvoiceLines { get; set; }
    }
}
