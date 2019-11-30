using System.Linq;
using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouseCleanersApi.BusinessLayer
{
    public class ServicesRep : RepositoryBase<Service>, IServicesRepo
    {
        public ServicesRep(clearnersDbContext context) : base(context)
        {
            
        }
        public IQueryable<Service> ServicesByProfessionnal(int professionalId)
        {
          
                       return _context.Services.Join(
                           _context.ProfessionalServices.Where(x => x.serviceId == professionalId),
                           d => d.serviceId,
                           f => f.serviceId,
                           (d, f) => d);
           
                       //  return _context.ProfessionalServices.Where(p => p.serviceId == serviceId).Include(e => e.professional);
           
                  
        }
    }
}