using System;
using System.Linq;

namespace _03.Spyfer
{
    public class Spyfer
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < input.Count; i++)
            {
                var currentNumber = input[i];
                
                if (i != 0 && i != input.Count - 1)
                {
                    var next = input[i + 1];
                    var prev = input[i - 1];

                    if (currentNumber == prev + next)
                    {
                        input.RemoveAt(i + 1);
                        input.RemoveAt(i - 1);

                        i = 0;
                    }
                }
                else if (i == 0 && currentNumber == input[i + 1])
                {
                    input.RemoveAt(i + 1);
                    i = 0;
                }
                else if (i == input.Count - 1 && currentNumber == input[i - 1])
                {
                    input.RemoveAt(i - 1);
                    i = 0;
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
