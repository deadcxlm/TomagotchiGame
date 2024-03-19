using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomagotchiGame.Models;

namespace TomagotchiGame.SharedDto
{
    public class TomagotchiDto
    {
        public TomagotchiDto(string name, int health, int hunger, int fatigue)
        {
            Name = name;
            Health = health;
            Hunger = hunger;
            Fatigue = fatigue;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Hunger { get; set; }
        public int Fatigue { get; set; }
    }
}
