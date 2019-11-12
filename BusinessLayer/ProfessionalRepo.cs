using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class ProfessionalRepo : RepositoryBase<Professionals>, IProfessionalRepo
    {
        public ProfessionalRepo(clearnersDbContext context) : base(context)
        {
            
        }
    }
}