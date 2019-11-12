using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string PlotNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PostCode { get; set; }
        public string GeoCoords { get; set; }
        public string Picture { get; set; }
        public User user { get; set; }
        public string userId { get; set; }
        
        [NotMapped]
        public string password { get; set; }
        [NotMapped]
        
        public string passwordComfirm { get; set; }
        

        public virtual ICollection<Invoices> Invoices { get; set; }
        public virtual ICollection<Plannings> Plannings { get; set; }
        public virtual ICollection<Reservations> Reservations { get; set; }
    }
}
