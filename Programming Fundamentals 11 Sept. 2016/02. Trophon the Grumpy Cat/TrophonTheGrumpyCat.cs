using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Trophon_the_Grumpy_Cat
{
    public class TrophonTheGrumpyCat
    {
        public static void Main()
        {
            var items = Console.ReadLine().Split().Select(long.Parse).ToList();
            var entryPoint = int.Parse(Console.ReadLine());
            var typeOfItems = Console.ReadLine();
            var typeOfPriceRatings = Console.ReadLine();

            long leftDamage = 0;
            long rightDamage = 0;

            leftDamage += CalculateLeft(items, entryPoint, typeOfItems, typeOfPriceRatings);
            rightDamage += CalculateRight(items, entryPoint, typeOfItems, typeOfPriceRatings);
            
            if (leftDamage > rightDamage)
            {
                Console.WriteLine($"Left - {leftDamage}");
            }
            else if (leftDamage < rightDamage)
            {
                Console.WriteLine($"Right - {rightDamage}");
            }
            else
            {
                Console.WriteLine($"Left - {leftDamage}");
            }
        }

        private static long CalculateRight(List<long> items, int entryPoint, string typeOfItems, string typeOfPriceRatings)
        {
            long rightDamage = 0;
            for (int i = entryPoint + 1; i < items.Count; i++)
            {
                if (typeOfItems == "cheap")
                {
                    if (typeOfPriceRatings == "positive")
                    {
                        if (items[i] < items[entryPoint] && items[i] > 0)
                        {
                            rightDamage += items[i];
                        }
                    }
                    else if (typeOfPriceRatings == "negative")
                    {
                        if (items[i] < items[entryPoint] && items[i] < 0)
                        {
                            rightDamage += items[i];
                        }
                    }
                    else if (typeOfPriceRatings == "all")
                    {
                        if (items[i] < items[entryPoint])
                        {
                            rightDamage += items[i];
                        }
                    }
                }
                else
                {
                    if (typeOfPriceRatings == "positive")
                    {
                        if (items[i] >= items[entryPoint] && items[i] > 0)
                        {
                            rightDamage += items[i];
                        }
                    }
                    else if (typeOfPriceRatings == "negative")
                    {
                        if (items[i] >= items[entryPoint] && items[i] < 0)
                        {
                            rightDamage += items[i];
                        }
                    }
                    else if (typeOfPriceRatings == "all")
                    {
                        if (items[i] >= items[entryPoint])
                        {
                            rightDamage += items[i];
                        }
                    }
                }
            }

            return rightDamage;
        }

        public static long CalculateLeft(List<long> items, int entryPoint, string typeOfItems, string typeOfPriceRatings)
        {
            long leftDamage = 0;
            for (int i = 0; i < entryPoint; i++)
            {
                if (typeOfItems == "cheap")
                {
                    if (typeOfPriceRatings == "positive")
                    {
                        if (items[i] < items[entryPoint] && items[i] > 0)
                        {
                            leftDamage += items[i];
                        }
                    }
                    else if (typeOfPriceRatings == "negative")
                    {
                        if (items[i] < items[entryPoint] && items[i] < 0)
                        {
                            leftDamage += items[i];
                        }
                    }
                    else if (typeOfPriceRatings == "all")
                    {
                        if (items[i] < items[entryPoint])
                        {
                            leftDamage += items[i];
                        }
                    }
                }
                else
                {
                    if (typeOfPriceRatings == "positive")
                    {
                        if (items[i] >= items[entryPoint] && items[i] > 0)
                        {
                            leftDamage += items[i];
                        }
                    }
                    else if (typeOfPriceRatings == "negative")
                    {
                        if (items[i] >= items[entryPoint] && items[i] < 0)
                        {
                            leftDamage += items[i];
                        }
                    }
                    else if (typeOfPriceRatings == "all")
                    {
                        if (items[i] >= items[entryPoint])
                        {
                            leftDamage += items[i];
                        }
                    }
                }
            }

            return leftDamage;
        }
    }
}
