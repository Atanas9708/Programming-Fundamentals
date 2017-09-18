using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Array_Modifier
{
    public class ArrayModifier
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().Select(long.Parse).ToList();

            while (true)
            {
                var commands = Console.ReadLine().Split();
                if (commands[0] == "end")
                {
                    break;
                }

                if (commands[0] == "swap")
                {
                    var firstIndex = int.Parse(commands[1]);
                    var secondIndex = int.Parse(commands[2]);
                    SwapElements(firstIndex, secondIndex, list);
                }
                else if (commands[0] == "multiply")
                {
                    var firstIndex = int.Parse(commands[1]);
                    var secondIndex = int.Parse(commands[2]);
                    MultiplyElements(firstIndex, secondIndex, list);
                }
                else
                {
                    DecreaseElements(list);
                }
            }

            Console.WriteLine(string.Join(", ", list));
        }

        public static void DecreaseElements(List<long> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] -= 1;
            }
        }

        public static void MultiplyElements(int firstIndex, int secondIndex, List<long> list)
        {
            if (list.Count >= 2)
            {
                var multipliedElement = list[firstIndex] * list[secondIndex];
                list[firstIndex] = multipliedElement;
            }

        }

        public static void SwapElements(int firstIndex, int secondIndex, List<long> list)
        {
            if (list.Count >= 2)
            {
                var elemToSwap = list[firstIndex];
                list[firstIndex] = list[secondIndex];
                list[secondIndex] = elemToSwap;
            }
        }
    }
}
