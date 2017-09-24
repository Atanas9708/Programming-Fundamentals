using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Phoenix_Grid
{
    public class PhoenixGrid
    {
        public static void Main()
        {
            var messageRegex = new Regex(@"^([^_\s]{3})(\.[^_\s]{3})*$");

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "ReadMe")
                {
                    break;
                }

                var messageMatch = messageRegex.Match(line);
                if (messageMatch.Success)
                {
                    var text = messageMatch.Value;
                    var firstDot = text.IndexOf('.');

                    if (firstDot >= 0)
                    {
                        var lastDot = text.LastIndexOf('.');

                        var firstPart = text.Substring(0, firstDot);
                        var secondPart = text.Substring(lastDot + 1).Reverse();
                        var secondPartReversed = string.Join("", secondPart);

                        if (firstPart == secondPartReversed)
                        {
                            Console.WriteLine("YES");
                        }
                        else
                        {
                            Console.WriteLine("NO");
                        }
                    }
                    else
                    {
                        if (text[0] == text[2])
                        {
                            Console.WriteLine("YES");
                        }
                        else
                        {
                            Console.WriteLine("NO");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }
    }
}