using TomagotchiGame.Controllers;
using TomagotchiGame.Models;
using TomagotchiGame.Views;

namespace TomagotchiGame
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Tomagotchi game!"
                + "\n\n\nPlease press any key to continue ...");

            IView view = new ConsoleView();
            ITomagotchi tomagotchi = null!;
            TomagotchiController controller = new TomagotchiController(view, tomagotchi);

            Console.ReadKey();

            while (true)
            {
                await controller.MainMenu();
            }
        }
    }
}
