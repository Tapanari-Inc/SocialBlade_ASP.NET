using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Utilities
{
    public static class HelperClass
    {
        public static string ConvertNumbers( int number )
        {
            if(number < 1000)//10^3
            {
                return number.ToString();
            }
            if(number < 1000000)//10^6 - K
            {
                return (number / 1000) + "K";
            }
            if(number < 1000000000)//10^9 - M
            {
                return (number / 1000000) + "M";
            }
            else
            {
                return (number / 1000000000) + "B";
            }
        }

        public static string SerializeDate( DateTime createDate )
        {
            TimeSpan elapsedTime = DateTime.Now - createDate;
            if (elapsedTime.Days<1)
            {
                return $"{createDate:HH:mm}";
            }
            if (elapsedTime.Days<7)
            {
                return $"{new string(createDate.DayOfWeek.ToString().Take(3).ToArray())} {createDate:HH:mm}";
            }
            if (createDate.Year==DateTime.Now.Year)
            {
                return $"{createDate:dd-MMM HH:mm}";
            }
            return $"{createDate:dd-MMM-yyyy}";
        }
    }
}
