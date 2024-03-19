namespace TomagotchiGame.Controllers
{
    public interface ITomagotchiController
    {
        Task StartGame();
        Task SaveGame(string fileName);
        Task LoadGame(string fileName);
        Task MainMenu();
        Task StartNewGame();
    }
}
