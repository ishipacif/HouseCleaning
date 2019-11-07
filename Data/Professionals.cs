using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Data
{
    public partial class Professionals
    {
        public Professionals()
        {
            Invoices = new HashSet<Invoices>();
            Plannings = new HashSet<Plannings>();
            Reservations = new HashSet<Reservations>();
        }

        public int ProfessionalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetName { get; set; }
        public string PlotNumber { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public string GeoCoords { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<Plannings> Plannings { get; set; }
        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
