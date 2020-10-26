using System;
using System.Collections.Generic;

namespace EjerciciosInnovation
{
    public class Calculator
    {
        private delegate bool Validate(string value);

        private static Dictionary<string, int> operators = new Dictionary<string, int>()
        {
            ["*"] = 0,
            ["/"] = 1,
            ["+"] = 2,
            ["-"] = 3
        };
        private const int MULTIPLY = 0;
        private const int DIVIDE = 1;

        private const int ADD = 2;

        private static bool Running = true;

        private static bool isValidOperator(string input)
        {
            return operators.ContainsKey(input);
        }

        private static int getFromDict(string key)
        {
            int value;
            operators.TryGetValue(key, out value);
            return value;
        }

        private static int calculate(int n1, int n2, int op)
        {
            switch (op)
            {
                case MULTIPLY:
                    return n1 * n2;
                case DIVIDE:
                    return n1 / n2;
                case ADD:
                    return n1 + n2;
                default:
                    return n1 - n2;
            }
        }

        private static int prompt(string message, string errorMessage, Func<string, bool> validator, Func<string, int> getInt)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            if (input == "")
            {
                Console.WriteLine("Exitting . . .");
                Running = false;
                throw new Exception();
            }

            if (!validator(input))
            {
                Console.WriteLine(errorMessage);
                return prompt(message, errorMessage, validator, getInt);
            }
            return getInt(input);
        }

        public static void Run()
        {
            int total = 0;
            bool hasTotal = false;
            while (Running)
            {
                int firstNumber = hasTotal ? total : prompt("Enter the first number", "Please enter a valid number", Util.isNumber, Int32.Parse);

                int op = prompt("Enter the operation (+, -, /, *)", "Please enter a valid operator", isValidOperator, getFromDict);

                int secondNumber = prompt("Enter the second number", "Please enter a valid number", Util.isNumber, Int32.Parse);

                total = calculate(firstNumber, secondNumber, op);
                Console.WriteLine($"The total of this operation is {total}");
                hasTotal = true;
            }
            Console.WriteLine($"The total of your operations is: {total}");
        }

    }
}
