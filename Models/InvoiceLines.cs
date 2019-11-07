using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Models
{
    public partial class InvoiceLines
    {
        public int InvoicelineId { get; set; }
        public int? InvoiceId1 { get; set; }
        public int? ReservationId1 { get; set; }
        public decimal HourCount { get; set; }
        public decimal HourPrice { get; set; }
        public decimal PourcentCommission { get; set; }
        public decimal PreCommission { get; set; }
        public decimal CommissionTotal { get; set; }
        public decimal Amount { get; set; }

        public virtual Invoices InvoiceId1Navigation { get; set; }
        public virtual Reservations ReservationId1Navigation { get; set; }
    }
}
