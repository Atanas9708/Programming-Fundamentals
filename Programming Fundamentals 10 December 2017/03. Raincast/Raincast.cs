using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.Raincast
{
    public class Raincast
    {
        public static void Main()
        {
            var typeRegex = new Regex(@"^Type: (Normal|Warning|Danger)$");
            var sourceRegex = new Regex(@"^Source: ([a-zA-Z0-9]+)$");
            var forecastRegex = new Regex(@"^Forecast: ([^!.,?]+)$");

            var currentType = string.Empty;
            var currentSource = string.Empty;
            var currentForecast = string.Empty;

            var validCounter = 0;
            var output = new List<string>();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "Davai Emo")
                {
                    break;
                }

                switch (validCounter)
                {
                    case 0:
                        if (typeRegex.IsMatch(line))
                        {
                            validCounter = 1;
                            currentType += typeRegex.Match(line).Groups[1];
                        }
                        break;
                    case 1:
                        if (sourceRegex.IsMatch(line))
                        {
                            validCounter = 2;
                            currentSource += sourceRegex.Match(line).Groups[1];
                        }
                        break;
                    case 2:
                        if (forecastRegex.IsMatch(line))
                        {
                            currentForecast += forecastRegex.Match(line).Groups[1];
                            output.Add($"({currentType}) {currentForecast} ~ {currentSource}");
                            validCounter = 0;
                            currentType = string.Empty;
                            currentSource = string.Empty;
                            currentForecast = string.Empty;
                        }
                        break;
                    default:
                        break;
                }

            }

            Console.WriteLine(string.Join(Environment.NewLine, output));
        }
    }
}
