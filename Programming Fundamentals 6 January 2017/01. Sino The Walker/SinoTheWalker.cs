using System;

namespace _01.Sino_The_Walker
{
   public class SinoTheWalker
    {
       public static void Main()
        {
            var leaving = TimeSpan.Parse(Console.ReadLine());
            var steps = int.Parse(Console.ReadLine()) % 86400;
            var seconds = int.Parse(Console.ReadLine()) % 86400;

            var sumSteps = steps * seconds;
            var time = TimeSpan.FromSeconds(sumSteps);
            var totalTime = leaving + time;

            Console.WriteLine("Time Arrival: {0:hh\\:mm\\:ss}", totalTime);
        }
    }
}
