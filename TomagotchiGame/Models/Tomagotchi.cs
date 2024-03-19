using System.Text.Json;
using TomagotchiGame.SharedDto;

namespace TomagotchiGame.Models
{
    public class Tomagotchi : ITomagotchi
    {
        private const int MAX_ATTRIBUTE_VALUE = 10;
        private const int MIN_ATTRIBUTE_VALUE = 0;

        private readonly Random random = new Random();

        private bool flagHeal = true;
        private const string FILE_NAME = "save.json";

        private TomagotchiModel _pet = null!;

        public void CreateNewPet(string name)
        {
            _pet = new TomagotchiModel(name);
        }

        public void Feed()
        {
            _pet.Hunger--;

            if (_pet.Hunger < MIN_ATTRIBUTE_VALUE)
            {
                _pet.Health--;
                _pet.Hunger = MIN_ATTRIBUTE_VALUE;
            }
            else if (_pet.Hunger == MIN_ATTRIBUTE_VALUE)
            {
                _pet.Health += 1;
                if (_pet.Health > MAX_ATTRIBUTE_VALUE)
                {
                    _pet.Health = MAX_ATTRIBUTE_VALUE;
                }
            }
        }

        public void Play()
        {
            _pet.Fatigue++;
            if (_pet.Fatigue > MAX_ATTRIBUTE_VALUE)
            {
                _pet.Fatigue = MAX_ATTRIBUTE_VALUE;
                _pet.Health--;
                _pet.Hunger++;
                if (_pet.Hunger > MAX_ATTRIBUTE_VALUE)
                {
                    _pet.Hunger = MAX_ATTRIBUTE_VALUE;
                    _pet.Health--;
                }
            }
            else if (_pet.Fatigue > 5 && _pet.Hunger < MAX_ATTRIBUTE_VALUE)
            {
                _pet.Hunger++;
            }
            else if (_pet.Hunger == MAX_ATTRIBUTE_VALUE)
            {
                _pet.Health--;
            }
        }

        public async Task Sleep()
        {
            if (_pet.Fatigue >= 7)
            {
                _pet.Fatigue = MIN_ATTRIBUTE_VALUE;

                if (_pet.Health < MAX_ATTRIBUTE_VALUE)
                {
                    _pet.Health++;
                }

                if (_pet.Hunger < MAX_ATTRIBUTE_VALUE)
                {
                    _pet.Hunger++;
                }
                else _pet.Health--;

                flagHeal = true;

                await Task.Delay(3000);
            }
        }

        public bool IsCritical()
        {
            return _pet.Health <= 0;
        }

        public void UpdateState()
        {

            if (_pet.Hunger > 7 || _pet.Fatigue > 7 || _pet.Health < 5)
            {
                _pet.State = TomagotchiStateEnum.Sad;
            }
            else
            {
                _pet.State = TomagotchiStateEnum.Happy;
            }
        }

        public void Heal()
        {
            if (flagHeal)
            {
                _pet.Health++;
                if (_pet.Health > MAX_ATTRIBUTE_VALUE)
                {
                    _pet.Health = MAX_ATTRIBUTE_VALUE;
                }
                flagHeal = false;
            }
        }

        public TomagotchiDto GetStatus()
        {
            return new TomagotchiDto(_pet.Name, _pet.Health, _pet.Hunger, _pet.Fatigue);
        }

        public void Revive()
        {
            _pet.Health = MAX_ATTRIBUTE_VALUE;
            _pet.Hunger = MIN_ATTRIBUTE_VALUE;
            _pet.Fatigue = MIN_ATTRIBUTE_VALUE;
        }
        public int GetState()
        {
            return (int)_pet.State;
        }
        public TomagotchiStateEnum SetState(TomagotchiStateEnum newState)
        {
            _pet.State= newState;
            return _pet.State;
        }

        public void Save()
        {
            if (!File.Exists(FILE_NAME))
            {
                File.Create(FILE_NAME).Close();
            }

            string json = JsonSerializer.Serialize(_pet);
            File.WriteAllText(FILE_NAME, json);
        }

        public bool Load()
        {
            if (!File.Exists(FILE_NAME))
            {
                File.Create(FILE_NAME).Close();
            }

            string json = File.ReadAllText(FILE_NAME);
            var deserializedJson = JsonSerializer.Deserialize<TomagotchiModel>(json);

            if (deserializedJson != null)
            {
                _pet = deserializedJson;
                return true;
            }
            return false;
        }
    }
}
