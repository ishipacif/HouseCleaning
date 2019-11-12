using HouseCleanersApi.Data;
using HouseCleanersApi.Interfaces;

namespace HouseCleanersApi.BusinessLayer
{
    public class ReservationsRepo : RepositoryBase<Reservations>, IReservationsRepo
    {
        public ReservationsRepo(clearnersDbContext context) : base(context)
        {
        }
    }
}