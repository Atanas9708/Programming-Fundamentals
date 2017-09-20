using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Files
{
    public class Files
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            var fileDictionary = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < lines; i++)
            {
                var line = Console.ReadLine();
                var splitTokens = line.Split("\\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var root = splitTokens[0];
                var fileInput = splitTokens[splitTokens.Length - 1];
                var fileTokens = fileInput.Split(';');
                var fileName = fileTokens[0];
                var fileSize = long.Parse(fileTokens[1]);

                if (!fileDictionary.ContainsKey(root))
                {
                    fileDictionary[root] = new Dictionary<string, long>();
                }

                if (!fileDictionary[root].ContainsKey(fileName))
                {
                    fileDictionary[root][fileName] = 0;
                }

                fileDictionary[root][fileName] = fileSize;
            }

            var filesToCheck = Console.ReadLine().Split();
            var extensionToCheck = filesToCheck[0];
            var rootToCheck = filesToCheck[2];
            var extensionRegex = new Regex(@"\.[a-zA-Z]+");
            var checkForMatches = 0;

            foreach (var root in fileDictionary)
            {
                var rootName = root.Key;
                var files = root.Value;
                if (rootName == rootToCheck)
                {
                    foreach (var file in files.OrderByDescending(f => f.Value).ThenBy(f => f.Key))
                    {
                        var extensionMatch = extensionRegex.Match(file.Key);
                        
                        if (extensionMatch.Success)
                        {
                            var extension = extensionMatch.Value.Trim('.');
                            
                            if (extension == extensionToCheck)
                            {
                                Console.WriteLine($"{file.Key.Trim()} - {file.Value} KB ");
                                checkForMatches++;
                            }
                        }
                    }
                }
            }
            if (checkForMatches == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
