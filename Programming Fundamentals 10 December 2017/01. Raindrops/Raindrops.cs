using System;

namespace _01.Raindrops
{
    public class Raindrops
    {
       public static void Main()
        {
            var regions = int.Parse(Console.ReadLine());
            var density = decimal.Parse(Console.ReadLine());

            decimal totalSum = 0;

            for (int i = 0; i < regions; i++)
            {
                var regionsInfo = Console.ReadLine().Split();
                var raindropsCount = decimal.Parse(regionsInfo[0]);
                var squareMeters = decimal.Parse(regionsInfo[1]);

                totalSum += raindropsCount / squareMeters;
            }

            if (density > 0)
            {
                Console.WriteLine($"{totalSum / density:f3}");
            } else
            {
                Console.WriteLine($"{totalSum:f3}");
            }

        }
    }
}
