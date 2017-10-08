using System;
using System.Linq;

namespace _03.Wormhole
{
   public class Wormhole
    {
       public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var steps = 0;

            for (int i = 0; i < input.Length; i++)
            {
                steps++;

                if (input[i] != 0)
                {
                    var IndexToGoBackAt = input[i];
                    input[i] = 0;
                    i = IndexToGoBackAt;
                }
            }

            Console.WriteLine(steps);
        }
    }
}
