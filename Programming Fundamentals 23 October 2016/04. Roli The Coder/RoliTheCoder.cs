using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Roli_The_Coder
{
   public class RoliTheCoder
    {
       public static void Main()
        {
            var book = new Dictionary<int, Dictionary<string, List<string>>>();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Time for Code")
                {
                    break;
                }

                var splitTokens = input.Split();
                var id = int.Parse(splitTokens[0]);
                var eventName = splitTokens[1];
                
                if (!eventName.StartsWith("#"))
                {
                    continue;
                }

                var participantsIndex = input.IndexOf("@");
                if (participantsIndex > 0)
                {
                    var participants = input.Substring(participantsIndex);
                    var splittedParticipants = participants.Split();

                    if (!book.ContainsKey(id))
                    {
                        book[id] = new Dictionary<string, List<string>>();
                    }

                    if (!book[id].ContainsKey(eventName))
                    {
                        book[id][eventName] = new List<string>();
                    }
                    
                    foreach (var participant in splittedParticipants)
                    {
                        if (!book[id][eventName].Contains(participant))
                        {
                            if (participant.StartsWith("@"))
                            {
                                book[id][eventName].Add(participant);
                            }
                        }
                    }
                }
                else
                {
                    if (!book.ContainsKey(id))
                    {
                        book[id] = new Dictionary<string, List<string>>();
                        book[id].Add(eventName, new List<string>());
                    }
                }
            }

            var orderedBook = new Dictionary<string, List<string>>();

            foreach (var kvp in book)
            {
                var id = kvp.Key;
                var events = book[id].ToArray();
                var eventName = events[0].Key;
                var participants = events[0].Value;
                orderedBook.Add(eventName, new List<string>());
                orderedBook[eventName].AddRange(participants.Distinct());
            }

            foreach (var kvp in orderedBook.OrderByDescending(e => e.Value.Count).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{kvp.Key.Substring(1)} - {kvp.Value.Count}");

                foreach (var participant in kvp.Value.OrderBy(p => p))
                {
                    Console.WriteLine($"{participant}");
                }
            }
        }
    }
}
