using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

///Implement Fractional Knapsack Algorithm in C# (O(nlogn))
namespace Knapsack
{
    public class Item
    {
        public int Value { get; set; }
        public int Weight { get; set; }
        public double Ratio => (double)Value / Weight;
    }
    public class KnapsackAlgorithm
    {
        public static double GetMaxValue(int capacity, List<Item> items)
        {
            items.Sort((a, b) => b.Ratio.CompareTo(a.Ratio));

            double totalValue = 0.0;
            int currentWeight = 0;

            foreach (var item in items)
            {
                if (currentWeight + item.Weight <= capacity)
                {
                    currentWeight += item.Weight;
                    totalValue += item.Value;
                }
                else
                {
                    int remaining = capacity - currentWeight;
                    totalValue += item.Ratio * remaining;
                    break;
                }
            }

            return totalValue;
        }

        static void Main(string[] args)
        {
            List<Item> items = new List<Item>
            {
                new Item {Value = 60, Weight = 10},
                new Item {Value = 100, Weight = 20},
                new Item {Value = 120, Weight = 30}
            };
           
            int capacity = 50;

            double result = GetMaxValue(capacity, items);
            Console.WriteLine("Maximum value in Knapsack = " + result);
        }
    }
}