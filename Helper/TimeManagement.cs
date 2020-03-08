using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HouseCleanersApi.Helper
{
    public static class TimeManagement
    {
        
       private static List<DateTime> GetDayOfweek(DateTime date)
        {
            var days = System.DayOfWeek.Sunday - date.DayOfWeek;
            var startDate = date.AddDays(days);
            List<DateTime> dates = new List<DateTime>();
            

            for (var i = 0; i < 7; i++)
            {
                var day=startDate.AddDays(i + 1).Date;
                if (day>=date)
                {
                    dates.Add((day));
                }

            }

            return dates;
        }

        public static List<List<DateTime>> GetWeekstab(DateTime date)
        {
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.InstalledUICulture;
            System.Globalization.Calendar cal = ci.Calendar;
            List<List<DateTime>> t = new List<List<DateTime>>();
            t.Add(GetDayOfweek(date));
            int n = cal.GetWeekOfYear(date, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            for (int i = 0; i < 3; i++)
            {
                n += 1;
                t.Add(GetDayOfweek(FirstDateOfWeek(date.Year, n, CultureInfo.InstalledUICulture)));

            }
            return t;
        }

        public static List<DateTime> GetWeeksSaison(DateTime date,string weekday="Monday")
        {
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.InstalledUICulture;
            System.Globalization.Calendar cal = ci.Calendar;
            List<DateTime> t = new List<DateTime>();
          
           
            
            int n = cal.GetWeekOfYear(date, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            for (int i = 0; i < 10; i++)
            {
                n += 1;
                t.Add(GetDayOfweek(FirstDateOfWeek(date.Year, n, CultureInfo.InstalledUICulture)).FirstOrDefault(x => x.DayOfWeek.ToString()==weekday));

            }
            return t;
        }
        private static DateTime FirstDateOfWeek(int year, int weekOfYear, System.Globalization.CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays((weekOfYear * 7) + 1);
            
        }
        public static List<DateTime> GenerateAvailabilties(DateTime start, DateTime end)
        {
            List<DateTime> appointments = new List<DateTime>();

            while (start.Hour< end.Hour)
            {
                var date = start;
                var timeSlot = new TimeSpan(1,0,0);
                appointments.Add(start);
                start = start.Add(timeSlot);
                
            }

            return appointments;

        }
    }
}
    

    
