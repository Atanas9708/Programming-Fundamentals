using System;

namespace _01.Resurrection
{
   public class Resurrection
    {
       public static void Main()
        {
            var phoenixes = int.Parse(Console.ReadLine());

            for (int i = 0; i < phoenixes; i++)
            {
                var bodyLength = long.Parse(Console.ReadLine());
                var bodyWidth = decimal.Parse(Console.ReadLine());
                var wingLength = long.Parse(Console.ReadLine());

                decimal totalYears = (bodyLength * bodyLength) * (bodyWidth + 2 * wingLength);
                
                Console.WriteLine(totalYears);
            }
        }
    }
}
