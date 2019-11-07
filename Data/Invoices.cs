using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Data
{
    public partial class Invoices
    {
        public Invoices()
        {
        }

        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceAmountTotal { get; set; }
        public int? ProfessionalId1 { get; set; }
        public int? CustomerId1 { get; set; }

        public virtual Customers CustomerId1Navigation { get; set; }
        public virtual Professionals ProfessionalId1Navigation { get; set; }
        public virtual ICollection<InvoiceLines> InvoiceLines { get; set; } = new HashSet<InvoiceLines>();
    }
}
