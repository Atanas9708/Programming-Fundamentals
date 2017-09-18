using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace _04.Winning_Ticket
{
   public class WinningTicket
    {
       public static void Main()
        {
            var tickets = Console.ReadLine().Split(',').Select(a => a.Trim()).ToArray();
            var winningTicket = new Regex(@"(@{6,}|\${6,}|#{6,}|\^{6,})");
            
            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                var leftHalf = ticket.Substring(0, ticket.Length / 2);
                var rightHalf = ticket.Substring(ticket.Length / 2);

                var leftMatch = winningTicket.Match(leftHalf);
                var rightMatch = winningTicket.Match(rightHalf);

                if (leftMatch.Success && rightMatch.Success)
                {
                    var winningSymbol = leftMatch.Value[0];
                    var minLength = Math.Min(leftMatch.Length, rightMatch.Length);

                    if (leftMatch.Length == 10 && rightMatch.Length == 10)
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - {minLength}{winningSymbol} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - {minLength}{winningSymbol}");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }
    }
}