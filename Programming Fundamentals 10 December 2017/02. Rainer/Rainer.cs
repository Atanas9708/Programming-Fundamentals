using System;
using System.Linq;

namespace _02.Rainer
{
   public class Rainer
    {
       public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var initialIndex = numbers.Last();
            var startingNumbers = numbers.Take(numbers.Count - 1).ToList();
            var steps = 0;
            
            while (true)
            {
                startingNumbers = startingNumbers.Select(n => n -= 1).ToList();
                for (int i = 0; i < startingNumbers.Count; i++)
                {
                    if (startingNumbers[i] == 0 && startingNumbers[initialIndex] != startingNumbers[i])
                    {
                        startingNumbers[i] = numbers[i];
                    }
                }
                if (startingNumbers[initialIndex] == 0)
                {
                    break;
                }
                steps++;

                var indexes = int.Parse(Console.ReadLine());
                initialIndex = indexes;
            }

            Console.WriteLine(string.Join(" ", startingNumbers));
            Console.WriteLine(steps);
        }
    }
}
