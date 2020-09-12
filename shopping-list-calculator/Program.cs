using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new Dictionary<decimal, string>(); // price then name to search by price
            decimal runningTotal = 0;
            int itemCount = 0;
            while (true)
            {
                decimal price;

                Console.WriteLine("\nProduct Name:");
                string name = Console.ReadLine();
                if (name == "None")
                {
                    break;
                }

                Console.WriteLine("Product Price:");
                string rawPrice = Console.ReadLine();
                if (rawPrice == "None")
                {
                    break;
                }
                try
                {
                    price = Convert.ToDecimal(rawPrice);
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Invalid Price");
                    continue;
                }

                price = (PriceChange(price));
                runningTotal += price;
                itemCount++;

                if (items.ContainsKey(price))
                {
                    items[price] = Convert.ToString(items[price] + ", " + name);
                }
                else
                {
                    items.Add(price, name);
                }
                
            }
            decimal maxPrice = items.Keys.Max();
            Console.WriteLine($"Most expensive item(s): {items[maxPrice]} for {maxPrice.ToString("C", CultureInfo.CurrentCulture)} (including VAT and other discounts)");

            decimal minPrice = items.Keys.Min();
            Console.WriteLine($"Least expensive item(s): {items[minPrice]} for {minPrice.ToString("C", CultureInfo.CurrentCulture)} (including VAT and other discounts)");

            Console.WriteLine($"Average price of {itemCount} items is {(runningTotal / itemCount).ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Total price: {runningTotal.ToString("C", CultureInfo.CurrentCulture)}");

        }
        static decimal PriceChange(decimal _value)
        {
            if (_value > 50)
            {
                _value = _value * 0.95m;
            }
            return _value * 1.2m;
        }

        
    }
}
     
