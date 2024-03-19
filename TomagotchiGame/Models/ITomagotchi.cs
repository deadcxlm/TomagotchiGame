using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomagotchiGame.Models
{
    public interface ITomagotchi
    {
        string Name { get; set; }
        int Health { get; set; }
        int Hunger { get; set; }
        int Fatigue { get; set; }
        TomagotchiStateEnum State { get; set; }

        void Feed();
        void Play();
        bool IsCritical();
        void UpdateState();
        Task Sleep();
        void Heal();
    }
}
