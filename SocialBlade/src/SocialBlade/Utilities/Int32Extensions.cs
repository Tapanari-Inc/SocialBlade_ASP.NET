using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialBlade.Utilities
{
    public static class Int32Extensions
    {
        public static string Format(this int number)
        {
            if (number<1000)//10^3
            {
                return number.ToString();
            }
            if (number<1000000)//10^6 - K
            {
                return (number/1000) + "K";
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
    }
}
