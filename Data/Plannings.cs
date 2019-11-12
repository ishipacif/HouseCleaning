using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseCleanersApi.Data
{
    public partial class Plannings
    {
        public int PlaningId { get; set; }
        [Required]
        public DateTime PlaningDate { get; set; }
        [Required]
        public DateTime StartHour { get; set; }
        [Required]
        public DateTime EndHour { get; set; }
        [Required]
        public TimeSpan TimeSlot { get; set; }
        [Required]
        public TimeSpan StartBreakTime { get; set; }
        [Required]
        public TimeSpan EndBreakTime { get; set; }
        public int? ProfessionalId1 { get; set; }

        public virtual Professionals ProfessionalId1Navigation { get; set; }
    }
}
