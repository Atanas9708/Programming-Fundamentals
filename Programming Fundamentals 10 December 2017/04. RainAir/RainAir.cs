using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RainAir
{
    public class RainAir
    {
        public static void Main()
        {
            var flightsInfo = new SortedDictionary<string, List<int>>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "I believe I can fly!")
                {
                    break;
                }

                var tokens = line.Split(" =".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (char.IsLetter(tokens[0][0]))
                {
                    var costumerName = tokens[0];

                    if (char.IsDigit(tokens[1][0]))
                    {
                        if (!flightsInfo.ContainsKey(costumerName))
                        {
                            flightsInfo[costumerName] = new List<int>();
                        }

                        flightsInfo[costumerName].AddRange(tokens.Skip(1).Select(int.Parse));
                    }
                    else
                    {
                        var costumerToCopy = tokens[1];
                        flightsInfo[costumerName] = new List<int>(flightsInfo[costumerToCopy]);
                    }
                }
            }

            foreach (var item in flightsInfo.OrderByDescending(x => x.Value.Count))
            {
                var sortedFlights = item.Value.OrderBy(x => x);
                Console.WriteLine($"#{item.Key} ::: {string.Join(", ", sortedFlights)}");
            }
        }
    }
}
