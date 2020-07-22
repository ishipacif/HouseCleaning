using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HouseCleanersApi.BusinessLayer
{
    public class ReservationsRepo : RepositoryBase<Reservation>, IReservationsRepo
    {
        public ReservationsRepo(clearnersDbContext context) : base(context)
        {
            
        }

        public Reservation GetOneReservation(int id)
       =>
             _context.Reservations
            .Include(x => x.professional)
            .Include(x=>x.status)
            .Include(x => x.Service)
            .ThenInclude(x => x.category)
            .FirstOrDefault(x => x.reservationId == id);

        public IEnumerable<Reservation> GetReservationByCustomer(int customerId)
        {
          var result=  _context.Reservations
              .Include(x => x.professional)
              .Include(x=>x.status)
              .Include(x => x.Service)
              .ThenInclude(x=>x.category)
              .Where(x => x.customerId == customerId && x.statusId==1).ToList();
            return result;
        }
        public IEnumerable<Reservation> GetReservationByProfessional(int profesionalId)
        => _context.Reservations
              .Include(x => x.professional)
              .Include(x => x.status)
              .Include(x => x.Service)
              .ThenInclude(x => x.category)
            .Where(x => x.professionalId == profesionalId);

    }
}