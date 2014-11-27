using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace _02_calendar
{
    class CalendarDrawer 
    {
        private DateTime date;
        private Graphics graphics;
        private Font font;
        private StringFormat stringFormat;
        private int imageSize;
        private CalendarDrawingPlacer calendarPlacer;

        public Color MonthNameColor { get; set; } 
        public Color DayColor { get; set; }
        public Color CurrentDayColor { get; set; }
        public Color HolidayColor { get; set; }

        public CalendarDrawer(DateTime date, int calendarSize = 400)
        {
            this.date = date;
            font = new Font("Arial", 14);
            stringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            calendarPlacer = new CalendarDrawingPlacer(calendarSize);
            imageSize = calendarSize;

            MonthNameColor = Color.DarkCyan;
            DayColor = Color.DarkSlateGray;
            HolidayColor = Color.DarkRed;
        }

        public Image DrawCurrentMonth()
        {
            var image = new Bitmap(imageSize, imageSize);
            graphics = Graphics.FromImage(image);
            graphics.Clear(Color.FloralWhite);

            DrawMonthName();
            DrawDaysOfWeek();
            DrawDaysNumbers();

            return image;
        }

        private void DrawMonthName()
        {
            var monthName = CalendarUtils.GetMonthNameByNumber(date.Month);
            
            using (var brush = new SolidBrush(MonthNameColor))
            {
                var drawingPoint = calendarPlacer.GetMonthNamePlace();
                graphics.DrawString(monthName, font, brush, drawingPoint, stringFormat);
            }
        }

        private void DrawDaysOfWeek()
        {
            var daysOfWeek = CalendarUtils.GetDaysOfWeek()
                .Select(day => string.Concat(day.Take(3)));

            DrawInCalendarGrid(daysOfWeek);
        }

        private void DrawInCalendarGrid(IEnumerable<string> toDraw)
        {
            var days = toDraw.ToArray();
        
            using (var normalBrush = new SolidBrush(DayColor))
            using (var currentDayBrush = new SolidBrush(CurrentDayColor))
            using (var holidayBrush = new SolidBrush(HolidayColor))
            {
                for (int i = 0; i < days.Count(); i++)
                {
                    var drawingRectangle = calendarPlacer.NextDatePlace();
                    if (i == date.Day)
                    {
                        graphics.FillEllipse(currentDayBrush, drawingRectangle);
                    }
                    var brush = IsHoliday(i) ? holidayBrush : normalBrush; 
                    graphics.DrawString(days[i], font, brush, drawingRectangle, stringFormat);
                }
            }
        }

        private bool IsHoliday(int i)
        {
            return CalendarUtils.Holidays.Contains(i+1);
        }

        private void DrawDaysNumbers()
        {
            var fistDayOfMonth = GetFirstDayOfWeekInCurrentMonth();
            var skipDays = (int)fistDayOfMonth - 1;
            var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            var dataToDraw = new List<string>();
            for (int i = 0; i < skipDays; i++)
            {
                dataToDraw.Add("");
            }
            for (int i = 1; i <= daysInMonth; i++)
            {
                dataToDraw.Add(i.ToString());
            }
            DrawInCalendarGrid(dataToDraw);
        }

        private CalendarUtils.DaysOfWeek GetFirstDayOfWeekInCurrentMonth()
        {
            var newDate = new DateTime(date.Year, date.Month, 1);
            return (CalendarUtils.DaysOfWeek) newDate.DayOfWeek;
        }
    }
}
