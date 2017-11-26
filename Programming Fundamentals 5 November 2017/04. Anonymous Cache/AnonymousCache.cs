using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Anonymous_Cache
{
    public class AnonymousCache
    {
        public static void Main()
        {
            var dataResult = new Dictionary<string, List<Data>>();
            var cache = new Dictionary<string, List<Data>>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(" |->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "thetinggoesskrra")
                {
                    break;
                }

                if (input.Length == 1)
                {
                    if (!dataResult.ContainsKey(input[0]) && !cache.ContainsKey(input[0]))
                    {
                        dataResult[input[0]] = new List<Data>();
                    }
                    else if (!dataResult.ContainsKey(input[0]) && cache.ContainsKey(input[0]))
                    {
                        dataResult[input[0]] = new List<Data>(cache[input[0]]);

                        //foreach (var data in cache[input[0]])
                        //{
                        //    dataResult[input[0]].Add(data);
                        //}
                    }
                }
                else
                {
                    var dataKey = input[0];
                    var dataSize = long.Parse(input[1]);
                    var dataSet = input[2];

                    var data = new Data();
                    data.dataKey = dataKey;
                    data.dataSize = dataSize;

                    if (!dataResult.ContainsKey(dataSet))
                    {
                        if (!cache.ContainsKey(dataSet))
                        {
                            cache[dataSet] = new List<Data>();
                        }

                        cache[dataSet].Add(data);
                    }
                    else
                    {
                        dataResult[dataSet].Add(data);
                    }
                }
            }

            var sortedData = dataResult.OrderByDescending(d => d.Value.Sum(x => x.dataSize)).Take(1);
            long totalSize = 0;

            foreach (var data in sortedData)
            {
                foreach (var item in data.Value)
                {
                    totalSize += item.dataSize;
                };
            }

            foreach (var data in sortedData)
            {
                Console.WriteLine($"Data Set: {data.Key}, Total Size: {totalSize}");
                foreach (var item in data.Value)
                {
                    Console.WriteLine($"$.{item.dataKey}");
                }
            }
        }
    }

    class Data
    {
        public string dataKey { get; set; }
        public long dataSize { get; set; }
    }
}
