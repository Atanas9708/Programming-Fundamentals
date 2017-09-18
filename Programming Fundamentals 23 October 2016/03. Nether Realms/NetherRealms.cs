using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Nether_Realms
{
    public class NetherRealms
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(Demon.Parse)
                .OrderBy(d => d.Name)
                .ToArray();
            
            foreach (var demon in input)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
            }
        }
    }

    public class Demon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public decimal Damage { get; set; }

        public static Demon Parse(string demonName)
        {
            var demon = new Demon();

            var healthPattern = @"([^0-9*\/+-\.])";
            var health = Regex.Matches(demonName, healthPattern)
                .Cast<Match>()
                .Select(d => char.Parse(d.Value))
                .ToArray();

            var damagePattern = @"([+-]?\d+(?:\.\d+)?)";
            var damage = Regex.Matches(demonName, damagePattern)
                .Cast<Match>()
                .Select(d => decimal.Parse(d.Value))
                .ToArray();

            demon.Health = CalculateHealth(health);
            demon.Damage = CalculateDamage(damage, demonName);
            demon.Name = demonName;
            
            return demon;
        }

        public static decimal CalculateDamage(decimal[] damage, string demonName)
        {
            var damageSum = 0m;
    
            foreach (var dmg in damage)
            {
                damageSum += dmg;
            }

            foreach (var letter in demonName)
            {
                switch (letter)
                {
                    case '*':
                        damageSum *= 2;
                        break;
                    case '/':
                        damageSum /= 2;
                        break;
                }
            }

            return damageSum;
        }

        public static int CalculateHealth(char[] health)
        {
            var healthValues = 0;
            foreach (var val in health)
            {
                healthValues += val;
            }

            return healthValues;
        }
    }
}
