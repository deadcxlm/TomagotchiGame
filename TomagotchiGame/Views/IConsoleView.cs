using TomagotchiGame.Models;
using TomagotchiGame.SharedDto;

namespace TomagotchiGame.Views
{
    public interface IView
    {
        void DisplayTomagotchiStatus(TomagotchiDto tomagotchiDto);
        void DisplayMessage(string message);
        void DisplayClear();
        void DisplayActionMenu();
        string GetUserInput();
        void DrawTomagotchi(TomagotchiStateEnum state);
        void DisplayMainMenu();
    }
}
