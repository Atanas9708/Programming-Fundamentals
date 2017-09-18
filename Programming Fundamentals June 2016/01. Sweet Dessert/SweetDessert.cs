using System;

namespace _01.Sweet_Dessert
{
   public class SweetDessert
    {
       public static void Main()
        {
            var money = decimal.Parse(Console.ReadLine());
            var guests = decimal.Parse(Console.ReadLine());
            var bananas = decimal.Parse(Console.ReadLine());
            var eggs = decimal.Parse(Console.ReadLine());
            var berries = decimal.Parse(Console.ReadLine());

            var portionsNeeded = Math.Ceiling(guests / 6);
            var moneyNeeded = (portionsNeeded * (2 * bananas))
                + (portionsNeeded * (4 * eggs)) + (portionsNeeded * (0.2m * berries));

            if (moneyNeeded <= money)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {moneyNeeded:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {Math.Abs(money - moneyNeeded):f2}lv more.");
            }
        }
    }
}
