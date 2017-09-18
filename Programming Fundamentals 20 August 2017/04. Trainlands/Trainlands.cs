using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Trainlands
{
   public class Trainlands
    {
       public static void Main()
        {
            var trains = new Dictionary<string, Dictionary<string, long>>();
            
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "It's Training Men!")
                {
                    break;
                }

                var splitTokens = input.Split(" :".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (splitTokens.Length == 4)
                {
                    var trainName = splitTokens[0];
                    var wagonName = splitTokens[2];
                    var wagonPower = int.Parse(splitTokens[3]);

                    if (!trains.ContainsKey(trainName))
                    {
                        trains[trainName] = new Dictionary<string, long>();
                    }

                    trains[trainName].Add(wagonName, wagonPower);

                }
                else
                {
                    var firstTrain = splitTokens[0];
                    var otherTrain = splitTokens[2];

                    if (splitTokens[1] == "->")
                    {
                        if (!trains.ContainsKey(firstTrain))
                        {
                            trains[firstTrain] = new Dictionary<string, long>();
                        }

                        foreach (var kvp in trains[otherTrain])
                        {
                            trains[firstTrain].Add(kvp.Key, kvp.Value);
                            trains.Remove(otherTrain);
                        }
                    }
                    else if(splitTokens[1] == "=")
                    {
                        if (!trains.ContainsKey(firstTrain))
                        {
                            trains[firstTrain] = new Dictionary<string, long>();
                        }

                        trains[firstTrain].Clear();

                        foreach (var kvp in trains[otherTrain])
                        {
                            trains[firstTrain].Add(kvp.Key, kvp.Value);
                        }
                    }
                }
            }

            foreach (var kvp in trains.OrderByDescending(x => x.Value.Values.Sum()))
            {
                var train = kvp.Key;
                Console.WriteLine($"Train: {train}");

                foreach (var item in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"###{item.Key} - {item.Value}");
                }
            }
        }
    }
}
