using System;

namespace _01.Wormtest
{
   public class Wormtest
    {
       public static void Main()
        {
            var wormsLength = decimal.Parse(Console.ReadLine()) * 100;
            var wormsWidth = decimal.Parse(Console.ReadLine());

            if (wormsWidth > 0)
            {
                if (wormsLength % wormsWidth == 0)
                {
                    var product = wormsLength * wormsWidth;
                    Console.WriteLine($"{product:f2}");
                }
                else
                {
                    var percentage = (wormsLength / wormsWidth) * 100;
                    Console.WriteLine($"{percentage:f2}%");
                }
            } else
            {
                Console.WriteLine($"{wormsLength * wormsWidth:f2}");
            }
        }
    }
}
