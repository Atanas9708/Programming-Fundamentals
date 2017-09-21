using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Spy_Gram
{
    public class SpyGram
    {
        public static void Main()
        {
            var privateKey = Console.ReadLine()
                .Select(x => x.ToString())
                .Select(int.Parse)
                .ToArray();
            var result = new Dictionary<string, List<string>>();

            while (true)
            {
                var commands = Console.ReadLine();
                if (commands == "END")
                {
                    break;
                }

                var regex = new Regex(@"TO: (?<recipient>[A-Z]+); MESSAGE: (?<message>.*);");
                var matches = regex.Match(commands);
                var strResult = string.Empty;

                if (matches.Success)
                {
                    var recipient = matches.Groups["recipient"].Value;
                    for (int i = 0; i < matches.Value.Length; i++)
                    {
                        int parsed = matches.Value[i];
                        var increasing = privateKey[i % privateKey.Length];
                        parsed += increasing;
                        strResult += (char)parsed;
                    }
                    if (!result.ContainsKey(recipient))
                    {
                        result[recipient] = new List<string>();
                    }

                    result[recipient].Add(strResult);
                }
            }

            foreach (var kvp in result.OrderBy(a => a.Key))
            {
                foreach (var message in kvp.Value)
                {
                    Console.WriteLine(message);
                }
            }
        }
    }
}
