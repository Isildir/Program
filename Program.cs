using System;
using System.Linq;

namespace Program
{
    public class Program
    {
        public static string BAD_ORDER = "Second date must be earlier than first one";

        public static string CompareDates(DateTime firstDate, DateTime secondDate)
        {
            if (firstDate.CompareTo(secondDate) >= 0)
                return BAD_ORDER;
            else if (firstDate.Month == secondDate.Month && firstDate.Year == secondDate.Year)
                return string.Format("{0} - {1}", firstDate.Day.ToString("00"), secondDate.ToShortDateString());
            else if (firstDate.Year == secondDate.Year)
                return string.Format("{0}.{1} - {2}", firstDate.Day.ToString("00"), firstDate.Month.ToString("00"), secondDate.ToShortDateString());
            else
                return string.Format("{0} - {1}", firstDate.ToShortDateString(), secondDate.ToShortDateString());
        }

        static void Main(string[] args)
        {
            string result;

            if (args.Count() != 2)
                result = "Invalid number of parameters";
            else if (DateTime.TryParse(args[0], out DateTime firstDate) && DateTime.TryParse(args[1], out DateTime secondDate))
                result = CompareDates(firstDate, secondDate);
            else
                result = "Invalid arguments formating";

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
