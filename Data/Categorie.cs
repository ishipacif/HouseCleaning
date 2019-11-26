using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseCleanersApi.Data
{
    public partial class Categorie
    {
        public Categorie()
        {
            Services = new HashSet<Service>();
        }

        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string CategoryDescription { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
