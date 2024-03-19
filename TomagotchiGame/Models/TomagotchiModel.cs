namespace TomagotchiGame.Models
{
    public class TomagotchiModel
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Hunger { get; set; }
        public int Fatigue { get; set; }
        public TomagotchiStateEnum State { get; set; }

        public TomagotchiModel(string name)
        {
            Name = name;
            Health = 10;
            Hunger = 0;
            Fatigue = 0;
        }
    }
}
