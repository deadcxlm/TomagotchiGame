using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
