using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosInnovation
{
    public class Shop
    {
        private static Dictionary<string, int> products = new Dictionary<string, int>()
        {
            ["moto"] = 100,
            ["computer"] = 50,
            ["mouse"] = 10,
            ["helicopter"] = 1000
        };

        private static Dictionary<string, int> selectedProducts = new Dictionary<string, int>();
        private struct DataFlow
        {
            public string value { get; set; }
            public bool shouldExit { get; set; }

        }

        private static bool isInStock(string product)
        {
            return products.ContainsKey(product.ToLower());
        }

        private static DataFlow prompt(string message, string errorMessage, Func<string, bool> validate)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            DataFlow flow = new DataFlow();

            if (input == "")
            {
                flow.shouldExit = true;
                return flow;

            }

            if (!validate(input))
            {
                Console.WriteLine(errorMessage);
                return prompt(message, errorMessage, validate);
            }
            flow.value = input;
            return flow;
        }


        private static int calculatePrice()
        {
            int total = 0;
            foreach (var entry in selectedProducts)
            {
                total += products[entry.Key] * entry.Value;
            }
            return total;
        }

        private static void printData()
        {
            int total = calculatePrice();
            if (selectedProducts.Count == 0)
            {
                Console.WriteLine("You did not order anything");
                return;
            }
            string message = "You ordered: ";
            string delimiter = selectedProducts.Count == 1 ? "" : ", ";
            foreach (var entry in selectedProducts)
            {
                string semanticAmount = entry.Value > 1 ? $"{entry.Key}s" : entry.Key;
                message += $"{entry.Value} {semanticAmount}{delimiter}";
            }
            Console.WriteLine(message);
            Console.WriteLine($"The total of your order is {total}");
        }

        public static void Run()
        {
            while (true)
            {
                DataFlow product = prompt("Please type the name of a product [helicopter, computer, mouse, moto]", "Enter a valid product", isInStock);
                if (product.shouldExit)
                {
                    Console.WriteLine("Exitting . . .");
                    break;
                }
                DataFlow quantity = prompt("Please enter the amount you need of this product", "Enter a valid number", Util.isNumber);
                if (quantity.shouldExit)
                {
                    Console.WriteLine("Exitting . . .");
                    return;
                }
                int _quantity = Int32.Parse(quantity.value);
                string lowerProduct = product.value.ToLower();
                if (selectedProducts.ContainsKey(lowerProduct))
                {
                    int newQuantity = selectedProducts[lowerProduct] + _quantity;
                    selectedProducts[lowerProduct] = newQuantity;
                }
                else
                {
                    selectedProducts.Add(lowerProduct, _quantity);
                }
            }
            printData();
        }
    }
}
