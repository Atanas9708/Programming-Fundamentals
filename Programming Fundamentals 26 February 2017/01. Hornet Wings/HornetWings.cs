using System;

namespace _01.Hornet_Wings
{
   public class HornetWings
    {
       public static void Main()
        {
            var flaps = int.Parse(Console.ReadLine());
            var distance = double.Parse(Console.ReadLine());
            var endurance = int.Parse(Console.ReadLine());

            var distanceInMeters = (flaps / 1000) * distance;
            var restTime = (flaps / endurance) * 5;
            var totalRestTime = restTime + (flaps / 100);

            Console.WriteLine("{0:f2} m.", distanceInMeters);
            Console.WriteLine("{0} s.", totalRestTime);
        }
    }
}
