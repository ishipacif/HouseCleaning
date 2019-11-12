using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class ServicesRep : RepositoryBase<Services>, IServicesRepo
    {
        public ServicesRep(clearnersDbContext context) : base(context)
        {
            
        }
    }
}