using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Anonymous_Threat
{
    public class AnonymousThreat
    {
       public static void Main()
        {
            var input = Console.ReadLine().Split().ToList();

            while (true)
            {
                var commands = Console.ReadLine().Split();
                if (commands[0] == "3:1")
                {
                    break;
                }

                var command = commands[0];
                var firstIndex = int.Parse(commands[1]);
                var secondIndex = int.Parse(commands[2]);
                var maxLength = input.Count;

                if (command == "merge")
                {

                    var startIndex = checkIndex(firstIndex, maxLength);
                    var endIndex = checkIndex(secondIndex, maxLength);

                    var start = Math.Min(startIndex, endIndex);
                    var end = Math.Max(startIndex, endIndex);

                    var newStr = string.Empty;
                    var count = 0;
                    for (int i = start; i <= end; i++)
                    {
                        newStr += input[i];
                        count++;
                    }

                    input.RemoveRange(start, count);
                    input.Insert(start, newStr);
                }
                else
                {
                    var wordToDivide = input[firstIndex];
                    var words = new List<string>();
                    var length = wordToDivide.Length / secondIndex;

                    if (wordToDivide.Length % secondIndex == 0)
                    {
                        for (int i = 0; i < wordToDivide.Length; i+= length)
                        {
                            words.Add(wordToDivide.Substring(i, length));
                        }
                    }
                    else
                    {
                        for (int i = 0; i < secondIndex; i++)
                        {
                            var start = i * length;
                            if (i == secondIndex - 1)
                            {
                                words.Add(wordToDivide.Substring(start));
                            }
                            else
                            {
                                words.Add(wordToDivide.Substring(start, length));
                            }
                        }
                        
                    }

                    input.RemoveAt(firstIndex);
                    input.InsertRange(firstIndex, words);
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }

        private static int checkIndex(int index, int maxLength)
        {
            if (index < 0)
            {
                index = 0;
            }
            else if (index >= maxLength)
            {
                index = maxLength - 1;
            }

            return index;
        }
    }
}
