using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Data
{
    public partial class Invoice
    {
        public Invoice()
        {
        }

        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceAmountTotal { get; set; }
        public int? ProfessionalId { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer customer { get; set; }
        public virtual Professional Professional { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; } = new HashSet<InvoiceLine>();
    }
}
