using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public static int Calculated(string firstDate, string secondDate)
        {
            DateTime dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);
            int result = Math.Abs((int)(dateOne - dateTwo).TotalDays);
            return result;
        }
    }
}
