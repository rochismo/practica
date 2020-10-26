using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosInnovation
{
    public class AgeGuesser
    {
        private static bool Running = true;
        private static int CURRENT_YEAR = Int32.Parse(DateTime.Now.ToString("yyyy"));
        public static bool isLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }

        private static int calculateYear(int age)
        {
            return CURRENT_YEAR - age;
        }

        private static List<int> getLeapYears(int year)
        {
            List<int> years = new List<int>();
            for (; year <= CURRENT_YEAR; year++)
            {
                if (isLeapYear(year))
                {
                    years.Add(year);
                }
            }
            return years;
        }

        private static int prompt()
        {
            Console.Write("Enter your age: ");
            string input = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrEmpty(input) || !Util.isNumber(input))
            {
                Console.WriteLine("Please enter a valid number");
                return prompt();
            }
            return Int32.Parse(input);
        }

        public static void Run()
        {
            int age = prompt();
            int birthYear = calculateYear(age);
            List<int> leapYears = getLeapYears(birthYear);

            Console.WriteLine($"You were born in {birthYear}");
            if (leapYears.Count == 0)
            {
                Console.WriteLine("There were no leap years since you were born");
            } else
            {
                Console.Write("There were the following leap years since you were born: ");
                leapYears.ForEach(year => Console.Write($"{year} "));
                Console.WriteLine();
            }

        }
    }
}
