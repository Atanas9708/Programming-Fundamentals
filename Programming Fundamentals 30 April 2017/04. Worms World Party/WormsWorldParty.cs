using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Worms_World_Party
{
    public class WormsWorldParty
    {
        public static void Main()
        {
            var result = new Dictionary<string, Dictionary<string, long>>();
            var wormList = new List<string>();

            while (true)
            {
                var line = Console.ReadLine().Split("->".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                if (line[0] == "quit")
                {
                    break;
                }

                var wormName = line[0];
                var teamName = line[1];
                var score = int.Parse(line[2]);
                
                if (!wormList.Contains(wormName))
                {
                    if (!result.ContainsKey(teamName))
                    {
                        result[teamName] = new Dictionary<string, long>();
                    }

                    if (!result[teamName].ContainsKey(wormName))
                    {
                        result[teamName][wormName] = 0;
                    }

                    result[teamName][wormName] += score;
                }

                wormList.Add(wormName);
            }

            var position = 1;

            foreach (var kvp in result.OrderByDescending(x => x.Value.Values.Sum())
                .ThenByDescending(x => x.Value.Values.Sum() / x.Value.Keys.Count()))
            {
                var resultScore = kvp.Value.Values.Sum();
                Console.WriteLine($"{position}. Team:{kvp.Key}- {resultScore}");

                foreach (var stats in kvp.Value.OrderByDescending(x => x.Value))
                {
                    var player = stats.Key;
                    var score = stats.Value;

                    Console.WriteLine($"###{player}: {score}");
                }

                position++;
            }
        }
    }
}
