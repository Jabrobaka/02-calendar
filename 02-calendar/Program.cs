using System;
using System.Drawing;

namespace _02_calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine(@"Expected 1 argument, but was " + args.Length);
                Console.WriteLine("Try again");
                Console.ReadKey();
                return;
            }

            DateTime date;
            try
            {
                date = DateTime.Parse(args[0]);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid date format\nTry again");
                Console.ReadKey();
                return;
            }

            var drawer = new CalendarDrawer(date);
            Image calendarImage = drawer.DrawCurrentDate();
            calendarImage.Save("result.bmp");
        }
    }
}
