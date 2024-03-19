using TomagotchiGame.Models;
using TomagotchiGame.SharedDto;

namespace TomagotchiGame.Views
{
    public class ConsoleView : IConsoleView
    {
        public void DisplayClear()
        {
            Console.Clear();
        }

        public void DisplayActionMenu()
        {
            Console.WriteLine("\nAction menu:");
            Console.WriteLine("1. Feed");
            Console.WriteLine("2. Play");
            Console.WriteLine("3. Sleep");
            Console.WriteLine("4. Heal");
            Console.WriteLine("5. Save");
            Console.WriteLine("6. Main menu");
            Console.Write("Choose an action: ");
        }

        public void DisplayMessage(string message)
        {
            Console.Write(message);
        }

        public void DisplayTomagotchiStatus(TomagotchiDto tomagotchiDto)
        {
            Console.WriteLine("───────────────────────────");
            Console.WriteLine($"Name:   {tomagotchiDto.Name}");
            Console.WriteLine($"Health: {tomagotchiDto.Health}");
            Console.WriteLine($"Hunger: {tomagotchiDto.Hunger}");
            Console.WriteLine($"Fatigue: {tomagotchiDto.Fatigue}");
            Console.WriteLine("───────────────────────────");
        }


        public string GetUserInput()
        {
            return Console.ReadLine()!;
        }

        public void DrawTomagotchi(TomagotchiStateEnum state)
        {
            switch (state)
            {
                case TomagotchiStateEnum.Happy:
                    Console.WriteLine("\t /\\_/\\\r\n\t( o.o )\r\n\t > ^ <");
                    break;
                case TomagotchiStateEnum.Sad:
                    Console.WriteLine("\t  /~~~\\\r\n\t / o o \\\r\n\t(   \"   )\r\n\t \\  -  /\r\n\t  \\___/");
                    break;
                case TomagotchiStateEnum.Dead:
                    Console.WriteLine("\t  ________\r\n\t /        \\\r\n\t|  R.I.P.  |\r\n\t \\________/");
                    break;
                case TomagotchiStateEnum.Sleep:
                    Console.WriteLine("\t  /\\_/\\  \r\n\t ( -.- ) \r\n\t  Zzzzz ");
                    break;
            }
        }
        public void DisplayMainMenu()
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
        }
    }
}
