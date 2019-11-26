using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class ProfessionalServiceRepo: RepositoryBase<ProfessionalService>,IProfessionalServiceRepo
    {
        public ProfessionalServiceRepo(clearnersDbContext context) : base(context)
        {
        }
    }
}