using System;
using System.Text.RegularExpressions;

namespace _03.Regexmon
{
    public class Regexmon
    {
       public static void Main()
        {
            var text = Console.ReadLine();

            var didisTurn = true;
            var keepGoing = true;

            var didiRegex = new Regex(@"[^a-zA-Z-]+");
            var bojoRegex = new Regex(@"[a-zA-Z]+-[a-zA-Z]+");

            while (keepGoing)
            {
                if (didisTurn)
                {
                    var match = didiRegex.Match(text);
                    if (match.Success)
                    {
                        Console.WriteLine(match.Value);
                        var startSubstr = text.IndexOf(match.Value[match.Value.Length - 1]);
                        text = text.Substring(startSubstr + 1);
                        didisTurn = false;
                    } else
                    {
                        keepGoing = false;
                    }
                }
                else
                {
                    var match = bojoRegex.Match(text);
                    if (match.Success)
                    {
                        Console.WriteLine(match.Value);
                        var startSubstr = text.IndexOf(match.Value[match.Value.Length - 1]);
                        text = text.Substring(startSubstr + 1);
                        didisTurn = true;
                    }
                    else
                    {
                        keepGoing = false;
                    }
                }
            }
        }
    }
}
