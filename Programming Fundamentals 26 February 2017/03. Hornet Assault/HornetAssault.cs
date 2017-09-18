using System;
using System.Linq;

namespace _03.Hornet_Assault
{
    public class HornetAssault
    {
        public static void Main()
        {
            var beehives = Console.ReadLine().Split().Select(long.Parse).ToList();
            var hornets = Console.ReadLine().Split().Select(long.Parse).ToList();
            
            for (int i = 0; i < beehives.Count; i++)
            {
                if (hornets.Count == 0)
                {
                    break;
                }

                var hornetsPower = hornets.Sum();
                var currentBee = beehives[i];

                beehives[i] -= hornetsPower;

                if (currentBee >= hornetsPower)
                {
                    hornets.RemoveAt(0);
                }


                currentBee -= hornetsPower;
            }

            if (beehives.Any(b => b > 0))
            {
                Console.WriteLine(string.Join(" ", beehives.Where(b => b > 0)));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}
