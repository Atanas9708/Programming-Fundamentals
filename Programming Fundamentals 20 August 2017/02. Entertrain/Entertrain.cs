using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Entertrain
{
   public class Entertrain
    {
       public static void Main()
        {
            var locomotivesPower = int.Parse(Console.ReadLine());
            var wagons = Console.ReadLine();
            var wagonsList = new List<int>();
            
            while (wagons != "All ofboard!")
            {
                wagonsList.Add(int.Parse(wagons));

                if (wagonsList.Sum() > locomotivesPower)
                {
                    var average = wagonsList.Sum() / wagonsList.Count;
                    var closest = wagonsList.OrderBy(e => Math.Abs(average - e)).First();
                    wagonsList.Remove(closest);

                }

                wagons = Console.ReadLine();
            }

            wagonsList.Reverse();
                
            Console.WriteLine(string.Join(" ", wagonsList) + " " + locomotivesPower);
        }
    }
}
