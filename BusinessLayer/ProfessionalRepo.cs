using System.Collections.Generic;
using System.Linq;
using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HouseCleanersApi.BusinessLayer
{
    public class ProfessionalRepo : RepositoryBase<Professional>, IProfessionalRepo
    {
        public ProfessionalRepo(clearnersDbContext context) : base(context)
        {
            
        }

        public IQueryable<Professional> ProfessionalByService(int serviceId)
        {
            return _context.Professionals.Join(
                _context.ProfessionalServices.Where(x => x.serviceId == serviceId),
                d => d.professionalId,
                f => f.professionalId,
                (d, f) => d);

            //  return _context.ProfessionalServices.Where(p => p.serviceId == serviceId).Include(e => e.professional);

        }
    }
}