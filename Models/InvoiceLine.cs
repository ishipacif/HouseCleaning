using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Models
{
    public class InvoiceLine
    {
        public InvoiceLine()
        {
                invoice=new Invoice();
                reservation=new Reservation();
        }
        public int invoicelineId { get; set; }
        public int? invoiceId { get; set; }
        public int? reservationId { get; set; }
        public double hourCount { get; set; }
        public double hourPrice { get; set; }
        public double pourcentCommission { get; set; }
        public double preCommission { get; set; }
        public double commissionTotal { get; set; }
        public double amount { get; set; }

        public Invoice invoice { get; set; }
        public Reservation reservation { get; set; }
    }
}
