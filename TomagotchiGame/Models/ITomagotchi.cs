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
