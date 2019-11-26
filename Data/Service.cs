using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseCleanersApi.Data
{
    public partial class Service
    {
        public Service()
        {
            Reservations = new HashSet<Reservation>();
            Professionals = new HashSet<ProfessionalService>();
            
        }

        public int ServiceId { get; set; }
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public string ServiceDescription { get; set; }
        [Required]
        public string ServiceCommission { get; set; }
        public int? CategoryId { get; set; }

        public virtual Categorie Category { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual IEnumerable<ProfessionalService> Professionals { get; set; }
    }
}
