using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HouseCleanersApi.Helper
{
    public static class TimeManagement
    {
        
        
        public static List<DateTime> planningDates(DateTime dateStart, DateTime dateEnd, bool saturday = false,
            bool sunday = false)
        {
            int count = 1;
            DateTime date = dateStart;
            var nbjr = (dateEnd - dateStart).Days;
            List<DateTime> periodes = new List<DateTime>();
            while (count <= nbjr)
            {
                if (date.DayOfWeek != DayOfWeek.Sunday && date.DayOfWeek != DayOfWeek.Saturday)
                {
                    periodes.Add(date);

                }

                if (date.DayOfWeek == DayOfWeek.Sunday && sunday)
                {
                    periodes.Add(date);
                }

                if (date.DayOfWeek == DayOfWeek.Saturday && saturday)
                {
                    periodes.Add(date);
                }

                count++;
                date = date.AddDays(1);

            }

            return periodes;
        }
        
        public static List<DateTime> plannningHours(List<DateTime> periods, TimeSpan startHour, TimeSpan endHour)
        {
            List<DateTime> disponibilities = new List<DateTime>();
            foreach (var p in periods)
            {
               
                for (int i = startHour.Hours; i < endHour.Hours; i++)
                {
                    DateTime mytime = p+ (new TimeSpan(i, 0, 0));
                    disponibilities.Add(mytime);
                }

            }

            return disponibilities; 
        }

    }
}
    

    
