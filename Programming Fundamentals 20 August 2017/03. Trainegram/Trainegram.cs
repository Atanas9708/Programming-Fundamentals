using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.Trainegram
{
   public class Trainegram
    {
       public static void Main()
        {
            var input = Console.ReadLine();

            var trainRegex = new Regex(@"^(<\[[^a-zA-Z0-9]*\]\.)(\.\[[a-zA-Z0-9]*\]\.)*$");
            var validTrains = new List<string>();

            while (input != "Traincode!")
            {
                var match = trainRegex.Match(input);

                if (match.Success)
                {
                    validTrains.Add(input);
                }

                input = Console.ReadLine();
            }
            
            Console.WriteLine(string.Join("\n", validTrains));
        }
    }
}
