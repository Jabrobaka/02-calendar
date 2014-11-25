using System;
using System.Drawing;

namespace _02_calendar
{
    class CalendarDrawer
    {
        private DateTime date;
        private Bitmap image;
        private Graphics graphics;

        private const int imageSize = 400;

        public CalendarDrawer(DateTime date)
        {
            this.date = date;
            image = new Bitmap(imageSize, imageSize);
            graphics = Graphics.FromImage(image);
        }

        public Image DrawCurrentMonth()
        {
            DrawMonthName();
            DrawDaysOfWeek();
            DrawDaysNumbers();

            return image;
        }

        private void DrawMonthName()
        {
            
        }

        private void DrawDaysOfWeek()
        {
            
        }

        private void DrawDaysNumbers()
        {
            
        }
    }
}
