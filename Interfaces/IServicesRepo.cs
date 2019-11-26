using System.Linq;
using HouseCleanersApi.Data;

namespace HouseCleanersApi.Interfaces
{
    public interface IServicesRepo: IRepositoryBase<Service>
    {
        IQueryable<Service> ServicesByProfessionnal(int professionalId);
    }
}