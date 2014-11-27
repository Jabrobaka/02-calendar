using System;
using System.Collections.Generic;

namespace _02_calendar
{
    public static class CalendarUtils
    {
        private static IEnumerable<int> holidays;

        public static IEnumerable<int> Holidays
        {
            get
            {
                if (holidays == null)
                {
                    var holidaysList = new List<int>();
                    for (int i = 1; i <= 5; i++)
                    {
                        holidaysList.Add(7*i);
                        holidaysList.Add(7*i-1);
                    }
                    holidays = holidaysList;
                }
                return holidays;
            }
        }

        public enum Months
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }

        public enum DaysOfWeek
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7,
        }

        public static string GetMonthNameByNumber(int monthNumber)
        {
            if (monthNumber >= 1 && monthNumber <= 12)
                return ((Months) monthNumber).ToString();
            throw new ArgumentOutOfRangeException("Month number number is invalid");
        }

        public static string GetDayOfWeeByNumber(int dayNumber)
        {
            if (dayNumber >= 1 && dayNumber <= 7)
            {
                return ((DaysOfWeek) dayNumber).ToString();
            }
            throw new ArgumentOutOfRangeException("Day number is invalid");
        }

        public static IEnumerable<string> GetDaysOfWeek()
        {
            for (int i = 1; i <= 7; i++)
            {
                yield return GetDayOfWeeByNumber(i);
            }
        } 
    }
}
