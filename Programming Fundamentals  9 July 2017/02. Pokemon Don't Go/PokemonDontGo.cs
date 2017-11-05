using System;
using System.Linq;

namespace _02.Pokemon_Don_t_Go
{
    public class PokemonDontGo
    {
       public static void Main()
        {
            var pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();
            var sum = 0;

            while (pokemons.Count > 0)
            {
                var index = int.Parse(Console.ReadLine());
                var elementToRemove = 0;

                if (index < 0)
                {
                    elementToRemove = pokemons[0];
                    sum += pokemons[0];
                    pokemons[0] = pokemons[pokemons.Count - 1];
                }
                else if (index > pokemons.Count - 1)
                {
                    elementToRemove = pokemons[pokemons.Count - 1];
                    sum += pokemons[pokemons.Count - 1];
                    pokemons[pokemons.Count - 1] = pokemons[0];
                }
                else
                {
                    elementToRemove = pokemons[index];
                    sum += elementToRemove;
                    pokemons.RemoveAt(index);
                }

               
                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= elementToRemove)
                    {
                        pokemons[i] += elementToRemove;
                    }
                    else
                    {
                        pokemons[i] -= elementToRemove;
                    }
                }

            }

            Console.WriteLine(sum);
        }
    }
}
