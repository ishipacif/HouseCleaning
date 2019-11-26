using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Data
{
    public partial class InvoiceLine
    {
        public int InvoicelineId { get; set; }
        public int? InvoiceId { get; set; }
        public int? ReservationId { get; set; }
        public decimal HourCount { get; set; }
        public decimal HourPrice { get; set; }
        public decimal PourcentCommission { get; set; }
        public decimal PreCommission { get; set; }
        public decimal CommissionTotal { get; set; }
        public decimal Amount { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Reservation Reservation{ get; set; }
    }
}
