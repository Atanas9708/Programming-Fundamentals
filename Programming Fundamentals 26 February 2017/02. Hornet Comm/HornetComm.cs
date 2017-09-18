using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Hornet_Comm
{
    public class HornetComm
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var messageRegex = new Regex(@"^(?<firstQuery>\d+) <-> (?<secondQuery>[a-zA-Z0-9]+)$");
            var broadcastRegex = new Regex(@"^(?<firstQuery>\D+) <-> (?<secondQuery>[a-zA-Z0-9]+)$");

            var messages = new List<string>();
            var broadcasts = new List<string>();

            while (input != "Hornet is Green")
            {
                var messageMatch = messageRegex.Match(input);
                var broadcastMatch = broadcastRegex.Match(input);

                if (messageMatch.Success)
                {
                    var recipientCode = messageMatch.Groups["firstQuery"].Value;
                    var message = messageMatch.Groups["secondQuery"].Value;

                    var resultMessage = string.Join("", recipientCode.Reverse()) + " " + "->" + " " + message;
                    messages.Add(resultMessage);
                }

                if (broadcastMatch.Success)
                {
                    var message = broadcastMatch.Groups["firstQuery"].Value;
                    var frequency = broadcastMatch.Groups["secondQuery"].Value;

                    var processedFrequency = "";

                    foreach (var token in frequency)
                    {
                        if (char.IsLower(token))
                        {
                            processedFrequency += (char)(token - (char)32);
                        }
                        else if (char.IsUpper(token))
                        {
                            processedFrequency += (char)(token + (char)32);
                        }
                        else
                        {
                            processedFrequency += token;
                        }
                    }

                    var newFrequency = processedFrequency + " " + "->" + " " + message;
                    broadcasts.Add(newFrequency);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Broadcasts:");
            if (broadcasts.Any())
            {
                foreach (var broadcast in broadcasts)
                {
                    Console.WriteLine(broadcast);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
            
            Console.WriteLine("Messages:");
            if (messages.Any())
            {
                foreach (var message in messages)
                {
                    Console.WriteLine(message);
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
