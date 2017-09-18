using System;
using System.Linq;

namespace _02.Ladybugs
{
   public class Ladybugs
    {
       public static void Main()
        {
            var arrSize = int.Parse(Console.ReadLine());
            var bugIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(i => i >= 0 && i < arrSize)
                .ToArray();

            var bugs = new int[arrSize];

            for (int i = 0; i < bugIndexes.Length; i++)
            {
                var currentBugIndex = bugIndexes[i];
                bugs[currentBugIndex] = 1;
            }
            
            while (true)
            {

                var command = Console.ReadLine().Split();
                if (command[0] == "end")
                {
                    break;
                }
                
                var startingPoint = int.Parse(command[0]);
                var direction = command[1];
                var endingPoint = int.Parse(command[2]);

                if (startingPoint < 0 || startingPoint >= bugs.Length)
                {
                    continue;
                }

                if (bugs[startingPoint] == 0)
                {
                    continue;
                }

                MoveLadyBug(startingPoint, endingPoint, direction, bugs);
                
            }

            Console.WriteLine(string.Join(" ", bugs));
            
        }

        public static void MoveLadyBug(int startingPoint, int endingPoint, string direction, int[] bugs)
        {
            bugs[startingPoint] = 0;
            var isSettled = false;

            while (!isSettled)
            {
                switch (direction)
                {
                    case "right":
                        startingPoint += endingPoint;
                        break;
                    case "left":
                        startingPoint -= endingPoint;
                        break;
                }

                if (startingPoint < 0 || startingPoint >= bugs.Length)
                {
                    isSettled = true;
                    continue;
                }

                if (bugs[startingPoint] == 1)
                {
                    continue;
                }

                if (bugs[startingPoint] == 0)
                {
                    bugs[startingPoint] = 1;
                    isSettled = true;
                    continue;
                }

            }
        }
    }
}
