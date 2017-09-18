using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hornet_Armada
{
   public class HornetArmada
    {
       public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<string, long> legionActivity = new Dictionary<string, long>();
            Dictionary<string, Dictionary<string, long>> legionSoldiers = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < lines; i++)
            {
                string[] splitTokens = Console.ReadLine().Split(" =->:".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                long activity = long.Parse(splitTokens[0]);
                string legionName = splitTokens[1];
                string soldierType = splitTokens[2];
                long soldierCount = long.Parse(splitTokens[3]);

                if (!legionActivity.ContainsKey(legionName))
                {
                    legionActivity[legionName] = activity;
                    legionSoldiers[legionName] = new Dictionary<string, long>();
                }

                if (!legionSoldiers[legionName].ContainsKey(soldierType))
                {
                    legionSoldiers[legionName][soldierType] = 0;
                }

                if (legionActivity[legionName] < activity)
                {
                    legionActivity[legionName] = activity;
                }

                legionSoldiers[legionName][soldierType] += soldierCount;
            }

            string[] command = Console.ReadLine().Split('\\');

            if (command.Length == 2)
            {
                long activity = long.Parse(command[0]);
                string soldierType = command[1];

                foreach (var legion in legionSoldiers
                    .Where(l => l.Value.ContainsKey(soldierType))
                    .OrderByDescending(l => l.Value[soldierType]))
                {
                    if (legionActivity[legion.Key] < activity)
                    {
                        Console.WriteLine($"{legion.Key} -> {legion.Value[soldierType]}");
                    }  
                }
            }
            else
            {
                string soldierType = command[0];
                foreach (var legion in legionActivity.OrderByDescending(l => l.Value))
                {
                    if (legionSoldiers[legion.Key].ContainsKey(soldierType))
                    {
                        Console.WriteLine($"{legion.Value} : {legion.Key}");
                    }
                }
            }
        }
    }
}
