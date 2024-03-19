using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomagotchiGame.Models
{
    public class Tomagotchi : ITomagotchi
    {
        private const int MAX_ATTRIBUTE_VALUE = 10;
        private const int MIN_ATTRIBUTE_VALUE = 0;

        private readonly Random random = new Random();

        public string Name { get; set; }
        public int Health { get; set; }
        public int Hunger { get; set; }
        public int Fatigue { get; set; }
        public TomagotchiStateEnum State { get; set; }

        public Tomagotchi(string name)
        {
            Name = name;
            Health = 10;
            Hunger = 0;
            Fatigue = 0;
        }

        public void Feed()
        {
            Hunger--;

            if (Hunger < MIN_ATTRIBUTE_VALUE)
            {
                Health--;
                Hunger = MIN_ATTRIBUTE_VALUE;
            }
            else if (Hunger == MAX_ATTRIBUTE_VALUE)
            {
                Health += 3;
                if (Health > MAX_ATTRIBUTE_VALUE)
                {
                    Health = MAX_ATTRIBUTE_VALUE;
                }
            }
        }

        public void Play()
        {
            Fatigue++;
            if (Fatigue > MAX_ATTRIBUTE_VALUE)
            {
                Fatigue = MAX_ATTRIBUTE_VALUE;
                Health--;
                Hunger++;
                if (Hunger > MAX_ATTRIBUTE_VALUE)
                {
                    Hunger = MAX_ATTRIBUTE_VALUE;
                    Health--;
                }
            }
            else if (Fatigue > 5 && Hunger < MAX_ATTRIBUTE_VALUE)
            {
                Hunger++;
            }
            else if (Hunger == MAX_ATTRIBUTE_VALUE)
            {
                Health--;
            }
        }

        public async Task Sleep()
        {
            Fatigue = MIN_ATTRIBUTE_VALUE;

            if (Health < MAX_ATTRIBUTE_VALUE)
            {
                Health++;
            }

            if (Hunger < MAX_ATTRIBUTE_VALUE)
            {
                Hunger++;
            }
            else Health--;

            await Task.Delay(3000);
        }

        public bool IsCritical()
        {
            return Health <= 0;
        }

        public void UpdateState()
        {

            if (Hunger > 7 || Fatigue > 7 || Health < 5)
            {
                State = TomagotchiStateEnum.Sad;
            }
            else
            {
                State = TomagotchiStateEnum.Happy;
            }
        }

    }
}
