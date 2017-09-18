using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Population_Aggregation
{
    public class PopulationAggregation
    {
        public static void Main()
        {
            var countryAndCities = new Dictionary<string, List<string>>();
            var cityAndPopulation = new Dictionary<string, long>();
            
            while (true)
            {
                var input = Console.ReadLine().Split('\\');
                if (input[0] == "stop")
                {
                    break;
                }
                
                var countryOrCity = Clean(input[0]);
                var population = long.Parse(input[2]);
                
                if (char.IsUpper(countryOrCity[0]))
                {
                    var city = Clean(input[1]);

                    if (!countryAndCities.ContainsKey(countryOrCity))
                    {
                        countryAndCities[countryOrCity] = new List<string>();
                    }

                    if (!cityAndPopulation.ContainsKey(city))
                    {
                        cityAndPopulation[city] = 0;
                    }

                    cityAndPopulation[city] = population;
                    countryAndCities[countryOrCity].Add(city);
                }
                else
                {
                    var country = Clean(input[1]);

                    if (!countryAndCities.ContainsKey(country))
                    {
                        countryAndCities[country] = new List<string>();
                    }

                    if (!cityAndPopulation.ContainsKey(countryOrCity))
                    {
                        cityAndPopulation[countryOrCity] = 0;
                    }

                    cityAndPopulation[countryOrCity] = population;
                    countryAndCities[country].Add(countryOrCity);
                }
            }

            foreach (var kvp in countryAndCities.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Count}");
            }

            foreach (var kvp in cityAndPopulation.OrderByDescending(c => c.Value).Take(3))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }

        public static string Clean(string str)
        {
            return str = Regex.Replace(str, @"([@#$&0-9]+)", "");
        }
    }
}
