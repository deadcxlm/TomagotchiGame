using TomagotchiGame.Models;

namespace TomagotchiGame.Views
{
    public interface IView
    {
        void DisplayTomagotchiStatus(string name, int health, int hunger, int fatigue);
        void DisplayMessage(string message);
        void DisplayClear();
        void DisplayActionMenu();
        string GetUserInput();
        void DrawTomagotchi(TomagotchiStateEnum state);
        void DisplayMainMenu();
    }
}
