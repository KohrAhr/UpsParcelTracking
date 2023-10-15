using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser3.Functions
{
    public static class DateTimeFunctions
    {
        #region Month
        public static DateTime GetFirstDayOfMonth(DateTime aDateTime)
        {
            // remove all days in the month
            // except the first day
           
            return aDateTime.AddDays(-(aDateTime.Day - 1));
        }

        public static DateTime GetLastDayOfMonth(DateTime aDateTime)
        {
            aDateTime = aDateTime.AddMonths(1);

            // remove all days in next month
            // previous month
            aDateTime = aDateTime.AddDays(-(aDateTime.Day));

            return aDateTime;
        }
        #endregion Month

        #region Year
        public static DateTime GetFirstDayOfYear(DateTime aDateTime)
        {
            return new DateTime(aDateTime.Year, 1, 1);
        }

        public static DateTime GetLastDayOfYear(DateTime aDateTime)
        {
            return new DateTime(aDateTime.Year, 12, 31);
        }
        #endregion Year

        #region Week
        public static DateTime GetFirstDayOfWeek(DateTime aDateTime, DayOfWeek aStartOfWeek = DayOfWeek.Monday)
        {
            DayOfWeek dayOfWeek = aDateTime.DayOfWeek;
            return GetDayMinusDays(aDateTime, (int)dayOfWeek - (int)aStartOfWeek);
        }

        public static DateTime GetLastDayOfWeek(DateTime aDateTime)
        {
            DateTime dateTime = GetFirstDayOfWeek(aDateTime);

            // Use GetDayMinusDays to Add days
            // Why -6 ? Because 1st day is already included
            return GetDayMinusDays(dateTime, - 6);
        }
        #endregion Week

        #region Custom
        /// <summary>
        ///     Get Date -- current date - X days
        /// </summary>
        /// <param name="aDays">Numbers of day to deduct</param>
        /// <returns>current date - X days</returns>
        public static DateTime GetDayMinusDays(DateTime aDateTime, int aDays)
        {
            return aDateTime.AddDays(-aDays);
        }
        #endregion Custom
    }
}
