using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class PlanningsRepo : RepositoryBase<Plannings>, IPlanningsRepo
    {
        public PlanningsRepo(clearnersDbContext context) : base(context)
        {
        }
    }
}