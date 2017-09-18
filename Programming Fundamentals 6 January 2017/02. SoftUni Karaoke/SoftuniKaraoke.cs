using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SoftUni_Karaoke
{
    public class SoftuniKaraoke
    {
        public static void Main()
        {
            var participants = Console.ReadLine().Split(',').Select(p => p.Trim()).ToList();
            var availableSongs = Console.ReadLine().Split(',').Select(s => s.Trim()).ToList();

            var awardsBook = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                var line = Console.ReadLine().Split(',').Select(p => p.Trim()).ToList();
                if (line[0] == "dawn")
                {
                    break;
                }

                var participant = line[0];
                var song = line[1];
                var award = line[2];

                if (participants.Contains(participant) && availableSongs.Contains(song))
                {
                    if (!awardsBook.ContainsKey(participant))
                    {
                        awardsBook[participant] = new HashSet<string>();
                    }

                    awardsBook[participant].Add(award);

                }
            }
            if (awardsBook.Any())
            {
                foreach (var kvp in awardsBook.OrderByDescending(p => p.Value.Count).ThenBy(n => n.Key))
                {
                    var participant = kvp.Key;
                    var awards = kvp.Value;
                    Console.WriteLine($"{participant}: {awards.Count} awards");
                    foreach (var award in awards.OrderBy(n => n))
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }
        }
    }
}