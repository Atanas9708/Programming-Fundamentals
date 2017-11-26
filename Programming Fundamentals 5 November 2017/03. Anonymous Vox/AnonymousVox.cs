using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Anonymous_Vox
{
    public class AnonymousVox
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var placeholders = Console.ReadLine()
                .Split("{}".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var regex = new Regex(@"([a-zA-Z]+)(.+)(\1)");
            var match = regex.Matches(text);
            var count = 0;
            
            foreach (Match item in match)
            {
                if (count >= placeholders.Count)
                {
                    break;
                }

                var value = item.Groups[2].Value;
                text = text.Replace(value, placeholders[count]);
                count++;
            }
            
            Console.WriteLine(text);
        }
    }
}
