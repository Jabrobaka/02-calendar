using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_calendar
{
    public static class CalendarUtils
    {
        private static IEnumerable<int> holidays = new[] { 7, 6, 14, 13, 21, 20, 28, 27, 35, 34 };

        public static IEnumerable<int> Holidays
        {
            get
            {
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
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday,
        }

        public static string GetMonthNameByNumber(this int monthNumber)
        {
            if (monthNumber >= 1 && monthNumber <= 12)
                return ((Months) monthNumber).ToString();
            throw new ArgumentOutOfRangeException("Month number number is invalid");
        }

        public static string GetDayOfWeekByNumber(this int dayNumber)
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
                yield return i.GetDayOfWeekByNumber();
            }
        }

        public static bool IsHoliday(this int i)
        {
            return Holidays.Contains(i + 1);
        }

        public static CalendarUtils.DaysOfWeek GetFirstDayOfWeekInCurrentMonth(this DateTime date)
        {
            var newDate = new DateTime(date.Year, date.Month, 1);
            return (DaysOfWeek)newDate.DayOfWeek;
        }
    }
}
