using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CODE_Phoenix_Oscar_Romeo_November
{
    public class PheonixOscar
    {
        public static void Main()
        {
            var creatureWithSquadMates = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Blaze it!")
                {
                    break;
                }

                var splitTokens = line.Split(" -> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var creature = splitTokens[0];
                var squadMate = splitTokens[1];

                if (creature != squadMate)
                {
                    if (!creatureWithSquadMates.ContainsKey(creature))
                    {
                        creatureWithSquadMates[creature] = new HashSet<string>();
                    }

                    creatureWithSquadMates[creature].Add(squadMate);
                }

            }

            var squadMatesWithCreatures = new Dictionary<string, int>();

            foreach (var kvp in creatureWithSquadMates)
            {
                var creature = kvp.Key;
                var count = kvp.Value.Count;

                squadMatesWithCreatures.Add(creature, count);

                foreach (var squad in kvp.Value)
                {
                    if (creatureWithSquadMates.ContainsKey(squad) && creatureWithSquadMates[squad].Contains(creature))
                    {
                        squadMatesWithCreatures[creature]--;
                    }
                }
            }

            foreach (var kvp in squadMatesWithCreatures.OrderByDescending(s => s.Value))
            {
                Console.WriteLine($"{kvp.Key} : {kvp.Value}");
            }
        }
    }
}
