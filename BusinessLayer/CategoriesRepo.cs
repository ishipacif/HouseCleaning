using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class CategoriesRepo : RepositoryBase<Categories>, ICategoriesRepo
    {
        public CategoriesRepo(clearnersDbContext context) : base(context)
        {
        }
    }
}