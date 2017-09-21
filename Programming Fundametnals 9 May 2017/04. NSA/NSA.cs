using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.NSA
{
   public class NSA
    {
       public static void Main()
        {
            var register = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                var input = Console.ReadLine().Split(" -> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "quit")
                {
                    break;
                }

                var countryName = input[0];
                var spyName = input[1];
                var daysInService = long.Parse(input[2]);

                if (!register.ContainsKey(countryName))
                {
                    register[countryName] = new Dictionary<string, long>();
                }

                if (!register[countryName].ContainsKey(spyName))
                {
                    register[countryName][spyName] = 0;
                }

                register[countryName][spyName] = daysInService;
            }

            foreach (var country in register.OrderByDescending(c => c.Value.Keys.Count))
            {
                var spys = country.Value;
                Console.WriteLine($"Country: {country.Key}");

                foreach (var spy in spys.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"**{spy.Key} : {spy.Value}");
                }
            }
        }
    }
}
