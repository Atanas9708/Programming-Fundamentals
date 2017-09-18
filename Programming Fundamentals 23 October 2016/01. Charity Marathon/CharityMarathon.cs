using System;

namespace _01.Charity_Marathon
{
   public class CharityMarathon
    {
       public static void Main()
        {
            var days = decimal.Parse(Console.ReadLine());
            var runners = decimal.Parse(Console.ReadLine());
            var laps = decimal.Parse(Console.ReadLine());
            var lapLength = decimal.Parse(Console.ReadLine());
            var capacity = decimal.Parse(Console.ReadLine());
            var money = decimal.Parse(Console.ReadLine());

            var maxCapacity = Math.Min(runners, capacity * days);
            var totalKilometers = (maxCapacity * laps * lapLength) / 1000;
            var moneyRaised = totalKilometers * money;

            Console.WriteLine("Money raised: {0:f2}", moneyRaised);
        }
    }
}
