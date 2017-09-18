using System;

namespace _01.Trainers
{
    class Trainers
    {
        static void Main()
        {
            int participants = int.Parse(Console.ReadLine());
            double maxIncome = Double.MinValue;
            string trainers = string.Empty;
            
            for (int i = 0; i < participants; i++)
            {
                int distance = int.Parse(Console.ReadLine()) * 1600;
                double cargo = double.Parse(Console.ReadLine()) * 1000;
                string team = Console.ReadLine();
                double fuelExpenses = 0.7 * distance * 2.5;
                double cargoIncome = 1.5 * cargo;
                double currentIncome = cargoIncome - fuelExpenses;

                if (currentIncome > maxIncome)
                {
                    maxIncome = currentIncome;
                    if (team == "Technical" || team == "Theoretical" || team == "Practical")
                    {
                        trainers = team;
                    }
                }

            }

            Console.WriteLine("The {0} Trainers win with ${1:f3}.", trainers, maxIncome);
        }
    }
}
