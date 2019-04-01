using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите дату");
            String sDate = Console.ReadLine();
            DateTime parsedDate;
            bool successfulParse = DateTime.TryParse(sDate, out parsedDate);
            if (!successfulParse)
            {
                Console.WriteLine("Не удалось распознать дату");
                Environment.Exit(0);
            }
            PrintMonth(parsedDate);
            Console.Read();
        }

        private static void PrintMonth(DateTime dateTime)
        {
            int weekends = 0;
            Console.WriteLine("ПН ВТ СР ЧТ ПТ СБ ВС");
            DateTime currentMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            int iDay = ((int)currentMonth.DayOfWeek - 1); // because 0 is SUNDAY
            if (iDay == -1)
            {
                iDay = 6
;
            }
            int offset = iDay * 3;
            for (int i = 0; i < offset; ++i)
            {
                Console.Write(" ");
            }
            int firstWeekDays = 7 - iDay;
            int day = 1;
            for (; day <= firstWeekDays; ++day)
            {
                if ((day + iDay - 1) % 7 == 5 || (day + iDay - 1) % 7 == 6)
                {
                    weekends++;
                }
                Console.Write("0" + day + " ");
            }
            int totalDays = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);
            day--;
            int weeksLeft = (totalDays - firstWeekDays) / 7 + ((totalDays - firstWeekDays) % 7 == 0 ? 0 : 1);
            for (int week = 0; week < weeksLeft; ++week)
            {
                Console.WriteLine();
                for (int i = 1; i <= 7 && day < totalDays; ++i)
                {
                    day++;
                    if ((day + iDay - 1) % 7 == 5 || (day + iDay - 1) % 7 == 6)
                    {
                        weekends++;
                    }
                    Console.Write(day < 10 ? ("0" + day + " ") : day + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Рабочих дней: " + (totalDays - weekends));
        }
    }
}
