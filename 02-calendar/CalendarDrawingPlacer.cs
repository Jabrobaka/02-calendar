using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_calendar
{
    class CalendarDrawingPlacer
    {
        private int side;
        private float startX;
        private float startY;
        private float currentX;
        private float currentY;
        private float rectangleWidth;
        private float rectangleHeight;
        private float lineSpace;

        public CalendarDrawingPlacer(int calendarSquareSide)
        {
            side = calendarSquareSide;
            currentX = startX = side * 0.05f;
            currentY = startY = side * 0.15f;
            rectangleWidth = (side - (startX+side*0.01f) * 2) / 7;
            rectangleHeight = side * 0.05f;
            lineSpace = side * 0.09f;
        }

        public PointF GetHeaderPlace()
        {
            var x = side * 0.5f;
            var y = side * 0.05f;
            return new PointF(x,y);
        }

        public RectangleF NextDatePlace()
        {
            
            var rectangle = new RectangleF(currentX, currentY, rectangleWidth, rectangleHeight);

            currentX += rectangle.Width;
            if (IsNeedToDrawNextLine(rectangle))
            {
                currentY += rectangle.Height + lineSpace;
                currentX = side * 0.05f;
            }
            return rectangle;
        }
        private bool IsNeedToDrawNextLine(RectangleF rectangle)
        {
            return currentX + rectangle.Width > side * 0.95f;
        }
    }
}
