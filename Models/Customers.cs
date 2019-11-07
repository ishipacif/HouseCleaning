using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Invoices = new List<Invoices>();;
            Reservations = new List<Reservations>();
        }

        public int CustomerId { get; set; }
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

        public  List<Invoices> Invoices { get; set; }
        public  List<Reservations> Reservations { get; set; }
    }
}
