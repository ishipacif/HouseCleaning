using System;
using System.Collections.Generic;

namespace HouseCleanersApi.Models
{
    public partial class Plannings
    {
        public int PlaningId { get; set; }
        public DateTime PlaningDate { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
        public TimeSpan TimeSlot { get; set; }
        public TimeSpan StartBreakTime { get; set; }
        public TimeSpan EndBreakTime { get; set; }
        public int? ProfessionalId1 { get; set; }

        public virtual Professionals ProfessionalId1Navigation { get; set; }
    }
}
