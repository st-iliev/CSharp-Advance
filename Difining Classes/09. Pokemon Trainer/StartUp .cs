using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp

    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<Trainer> trainers = new List<Trainer>();
            while (commands[0] != "Tournament")
            {
                string trainerName = commands[0];
                string pokemonName = commands[1];
                string pokemonElement = commands[2];
                decimal pokemonHealth = decimal.Parse(commands[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                List<Pokemon> pokemons = new List<Pokemon> { pokemon };
                Trainer trainer = new Trainer(trainerName, 0, pokemons);
                bool isFound = false;
                foreach (var item in trainers)
                {
                    if (item.Name == trainerName)
                    {
                        item.Pokemon.Add(pokemon);
                        isFound = true;
                        break;
                    }
                }
                if (!isFound)
                {
                    trainers.Add(trainer);
                }
                commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            string typeOfElements = Console.ReadLine();
            while (typeOfElements != "End")
            {
                foreach (var item in trainers)
                {
                    bool isFound = false;
                    foreach (var poke in item.Pokemon)
                    {
                        if (poke.Element == typeOfElements)
                        {
                            item.NumberOfBadges += 1;
                            isFound = true;
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        foreach (var kvp in item.Pokemon)
                        {
                            kvp.Health -= 10;
                            if (kvp.Health <= 0)
                            {
                                item.Pokemon.Remove(kvp);
                                break;
                            }
                        }
                        
                    }
                }
                typeOfElements = Console.ReadLine();
            }
            foreach (var trainer in trainers.OrderByDescending(s => s.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemon.Count}");
            }
        }
    }
}
