namespace TomagotchiGame.Controllers
{
    public interface ITomagotchiController
    {
        Task StartGame();
        Task SaveGame();
        Task LoadGame();
        Task MainMenu();
        Task StartNewGame();
    }
}
