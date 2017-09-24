using System;
using System.Linq;

namespace _02.Icarus
{
   public class Icarcus
    {
       public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var startingPosition = int.Parse(Console.ReadLine());

            var damage = 1;

            while (true)
            {
                var commands = Console.ReadLine().Split();
                if (commands[0] == "Supernova")
                {
                    break;
                }

                var direction = commands[0];
                var steps = int.Parse(commands[1]);

                if (direction == "left")
                {
                    var leftCount = 1;

                    while (leftCount <= steps)
                    {
                        var nextLeftPosition = startingPosition - leftCount;

                        if (nextLeftPosition < 0)
                        {
                            nextLeftPosition = numbers.Count - 1;
                            startingPosition = nextLeftPosition;
                            damage++;
                            steps -= leftCount;
                            leftCount = 0;
                        }

                        numbers[nextLeftPosition] -= damage;
                        leftCount++;
                    }

                    startingPosition = Math.Abs(startingPosition - steps) % numbers.Count;
                }
                else
                {
                    var rightCount = 1;

                    while (rightCount <= steps)
                    {
                        var nextRightPosition = (startingPosition + rightCount) % numbers.Count;

                        if (nextRightPosition == 0)
                        {
                            damage++;
                        }

                        numbers[nextRightPosition] -= damage;
                        rightCount++;
                    }

                    startingPosition = (startingPosition + steps) % numbers.Count;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
