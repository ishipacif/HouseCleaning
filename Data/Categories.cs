using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseCleanersApi.Data
{
    public partial class Categories
    {
        public Categories()
        {
            Services = new HashSet<Services>();
        }

        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string CategoryDescription { get; set; }

        public virtual ICollection<Services> Services { get; set; }
    }
}
