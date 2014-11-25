using System;

namespace _02_calendar
{
    public class CalendarUtils
    {
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

        public static string GetMonthNameByNumber(int monthNumber)
        {
            if (monthNumber >= 1 && monthNumber <= 12)
                return ((Months) monthNumber).ToString();
            throw new ArgumentOutOfRangeException("Month number number is invalid");
        }
    }
}
