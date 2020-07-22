using HouseCleanersApi.Data;
using System.Collections.Generic;

namespace HouseCleanersApi.Interfaces
{
    public interface IReservationsRepo: IRepositoryBase<Reservation>
    {

        Reservation GetOneReservation(int id);
        IEnumerable<Reservation> GetReservationByCustomer(int customerId);
        IEnumerable<Reservation> GetReservationByProfessional(int profesionalId);
    }
}