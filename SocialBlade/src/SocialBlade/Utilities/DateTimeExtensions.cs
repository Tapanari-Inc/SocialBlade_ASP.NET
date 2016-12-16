using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Utilities
{
    public static class DateTimeExtensions
    {
        public static string FormatDate(this DateTime createDate)
        {
            TimeSpan elapsedTime = DateTime.Now - createDate;
            if (elapsedTime.Days < 1)
            {
                return $"{createDate:HH:mm}";
            }
            if (elapsedTime.Days < 7)
            {
                return $"{new string(createDate.DayOfWeek.ToString().Take(3).ToArray())} {createDate:HH:mm}";
            }
            if (createDate.Year == DateTime.Now.Year)
            {
                return $"{createDate:dd-MMM HH:mm}";
            }
            return $"{createDate:dd-MMM-yyyy}";
        }
    }
}
