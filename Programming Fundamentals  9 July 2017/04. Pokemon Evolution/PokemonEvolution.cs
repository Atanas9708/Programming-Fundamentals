using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Pokemon_Evolution
{
    public class PokemonEvolution
    {
       public static void Main()
        {
            var pokemons = new Dictionary<string, List<Pokemon>>();

            while (true)
            {
                var line = Console.ReadLine().Split("-> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (line[0] == "wubbalubbadubdub")
                {
                    break;
                }
                
                if (line.Length != 1)
                {
                    var pokemonName = line[0];
                    var evolutionType = line[1];
                    var evolutionIndex = long.Parse(line[2]);

                    if (!pokemons.ContainsKey(pokemonName))
                    {
                        pokemons[pokemonName] = new List<Pokemon>();
                    }

                    var pokemon = new Pokemon();
                    pokemon.type = evolutionType;
                    pokemon.index = evolutionIndex;
                    pokemons[pokemonName].Add(pokemon);
                } 
                else
                {
                    var pokemonName = line[0];
                    if (pokemons.ContainsKey(pokemonName))
                    {
                        Console.WriteLine($"# {pokemonName}");
                        var evolutions = pokemons[pokemonName];
                        foreach (var evolution in evolutions)
                        {
                            Console.WriteLine($"{evolution.type} <-> {evolution.index}");
                        }
                    }
                }

            }

            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"# {pokemon.Key}");
                foreach (var evolution in pokemon.Value.OrderByDescending(p => p.index))
                {
                    Console.WriteLine($"{evolution.type} <-> {evolution.index}");
                }
            }
        }
    }


    class Pokemon
    {
        public string type { get; set; }
        public long index { get; set; }
    }
}
