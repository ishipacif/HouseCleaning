using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Models
{
    public class Service
    {
        public Service()
        {
        
        }

        public int serviceId { get; set; }

        public string serviceName { get; set; }
        public string serviceDescription { get; set; }
        public int? categoryId { get; set; }
        public double price { get; set; } 


        public Category category { get; set; }
      
    }
}
