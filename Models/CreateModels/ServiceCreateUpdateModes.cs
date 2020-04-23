namespace HouseCleanersApi.Models
{
    public class ServiceCreateUpdateModes
    {
        public ServiceCreateUpdateModes()
        {
        
        }

        public int serviceId { get; set; }
        public string serviceName { get; set; }
        public string serviceDescription { get; set; }
        public string serviceCommission { get; set; }
        public int categorieId { get; set; }


    }
}