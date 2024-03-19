using TomagotchiGame.SharedDto;

namespace TomagotchiGame.Models
{
    public interface ITomagotchi
    {
        void Feed();
        void Play();
        bool IsCritical();
        void UpdateState();
        Task Sleep();
        void Heal();
        void CreateNewPet(string name);
        TomagotchiDto GetStatus();
        void Revive();
        int GetState();
        TomagotchiStateEnum SetState(TomagotchiStateEnum newState);
        void Save();
        bool Load();
    }
}
