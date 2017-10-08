using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02.Worm_Ipsum
{
    public class WormIpsum
    {
        public static void Main()
        {

            while (true)
            {
                var lines = Console.ReadLine();
                if (lines == "Worm Ipsum")
                {
                    break;
                }

                var regex = new Regex(@"^[A-Z][^.]*\.$");
                var match = regex.Match(lines);

                if (match.Success)
                {
                    var validSentence = match.Value.Split();

                    foreach (var word in validSentence.Select(x => x.Trim('.', ',')))
                    {
                        var replacedWord = getMostFrequentChar(word);
                        lines = lines.Replace(word, replacedWord);
                    }

                    Console.WriteLine(lines);
                }
            }
        }
        
        private static string getMostFrequentChar(string word)
        {
            var mostOccuring = 0;
            var mostOccuringChar = ' ';

            foreach (var currentChar in word)
            {
                var foundCharOccurence = 0;
                foreach (var charToBeMatch in word)
                {
                    if (currentChar == charToBeMatch)
                    {
                        foundCharOccurence++;
                    }
                }
                if (mostOccuring < foundCharOccurence)
                {
                    mostOccuring = foundCharOccurence;
                    mostOccuringChar = currentChar;
                }
            }
            if (mostOccuring >= 2)
            {
                var replacer = new string(mostOccuringChar, word.Length);
                word = word.Replace(word, replacer);
            }

            return word;
        }
    }
}
