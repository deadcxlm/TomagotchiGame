using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
