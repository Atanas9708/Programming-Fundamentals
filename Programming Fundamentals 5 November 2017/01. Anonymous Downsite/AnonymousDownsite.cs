using System;
using System.Collections.Generic;
using System.Numerics;

namespace _01.Anonymous_Downsite
{
   public class AnonymousDownsite
    {
       public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var key = int.Parse(Console.ReadLine());
            var sites = new List<string>();
            decimal totalLoss = 0;

            
            for (int i = 0; i < lines; i++)
            {
                var websites = Console.ReadLine().Split();
                var siteName = websites[0];
                var siteVisits = long.Parse(websites[1]);
                var pricePerVisit = decimal.Parse(websites[2]);

                totalLoss += siteVisits * pricePerVisit;

                sites.Add(siteName);
            }

            foreach (var website in sites)
            {
                Console.WriteLine(website);
            }

            Console.WriteLine($"Total Loss: {$"{totalLoss:f20}"}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(new BigInteger(key), lines)}");
        }
    }
}
