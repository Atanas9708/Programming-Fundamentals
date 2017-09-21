using System;

namespace _01.Splinter_Trip
{
    public class SplinterTrip
    {
        public static void Main()
        {
            var distance = decimal.Parse(Console.ReadLine());
            var fuelCapacity = decimal.Parse(Console.ReadLine());
            var miles = decimal.Parse(Console.ReadLine());

            var milesInNonHeavyWinds = distance - miles;
            var nonHeavyWindsConsumption = milesInNonHeavyWinds * 25;
            var heavyWindsConsumption = miles * (25m * 1.5m);
            var fuelConsumption = nonHeavyWindsConsumption + heavyWindsConsumption;
            var tolerance = fuelConsumption * 0.05m;
            var totalFuelConsumption = fuelConsumption + tolerance;

            var fuelToSpare = fuelCapacity - totalFuelConsumption;

            Console.WriteLine($"Fuel needed: {totalFuelConsumption:f2}L");
            if (fuelCapacity >= totalFuelConsumption)
            {
                Console.WriteLine($"Enough with {fuelToSpare:f2}L to spare!");
            }
            else
            {
                Console.WriteLine($"We need {Math.Abs(totalFuelConsumption - fuelCapacity):f2}L more fuel.");
            }
        }
    }
}
