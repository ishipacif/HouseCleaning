using System;

namespace HouseCleanersApi.Models
{
    public class ReservationCreateUpdateModel
    {
        public int reservationId { get; set; }
        public int  disponibilityId {get;set;}
        public int customerId { get; set; }
        public int ServiceId { get; set; }
    }
}