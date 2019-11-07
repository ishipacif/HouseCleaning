using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Data
{
    public partial class Categories
    {
        public Categories()
        {
            Services = new HashSet<Services>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<Services> Services { get; set; }
    }
}
