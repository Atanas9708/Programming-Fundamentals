using System;

namespace _01.Poke_Mon
{
    public class Program
    {
       public static void Main()
        {
            var pokePower = long.Parse(Console.ReadLine());
            var distance = long.Parse(Console.ReadLine());
            var exhaustion = long.Parse(Console.ReadLine());

            var count = 0;
            var originalPower = (pokePower * 100) / 2;

            while (pokePower >= distance)
            {
                pokePower -= distance;

                if ((pokePower * 100) == originalPower && exhaustion != 0)
                {
                    pokePower /= exhaustion;
                }

                count++;
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(count);
        }
    }
}
