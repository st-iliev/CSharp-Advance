using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer(string name, int numberOfBadges, List<Pokemon> pokemon)
        {
            Name = name;
            NumberOfBadges = numberOfBadges;
            Pokemon = pokemon;
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemon { get; set; }
    }
}
