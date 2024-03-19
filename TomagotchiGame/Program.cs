using TomagotchiGame.Controllers;
using TomagotchiGame.Models;
using TomagotchiGame.Views;

namespace TomagotchiGame
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Tomagotchi game!");

            // Запрос имени у пользователя
            Console.Write("Enter the name for your pet: ");
            string petName = Console.ReadLine()!;

            ITomagotchi tomagotchi = new Tomagotchi(petName);

            // Создание экземпляра представления
            IView view = new ConsoleView();

            // Создание экземпляра контроллера и передача ему модели и представления
            TomagotchiController controller = new TomagotchiController(tomagotchi, view);

            // Запуск игры
            await controller.StartGame();
        }
    }
}
