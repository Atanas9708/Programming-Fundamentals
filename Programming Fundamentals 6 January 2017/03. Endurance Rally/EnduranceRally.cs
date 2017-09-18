using System;
using System.Linq;

namespace _03.Endurance_Rally
{
   public class EnduranceRally
    {
       public static void Main()
        {
            var driversNames = Console.ReadLine().Split();
            var zones = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            var checkpoints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
           
            for (int i = 0; i < driversNames.Length; i++)
            {
                double startingFuel = driversNames[i].First();

                for (int zone = 0; zone < zones.Count; zone++)
                {
                    if (checkpoints.Contains(zone))
                    {
                        startingFuel += zones[zone];
                    }
                    else
                    {
                        startingFuel -= zones[zone];
                    }

                    if (startingFuel <= 0)
                    {
                        Console.WriteLine($"{driversNames[i]} - reached {zone}");
                        break;
                    }
                }

                if (startingFuel > 0)
                {
                    Console.WriteLine($"{driversNames[i]} - fuel left {startingFuel:f2}");
                }
            }
           
        }
    }
}
