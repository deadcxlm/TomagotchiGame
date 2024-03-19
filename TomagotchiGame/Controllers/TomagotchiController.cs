using System.Data;
using System.Text.Json;
using TomagotchiGame.Models;
using TomagotchiGame.Views;

namespace TomagotchiGame.Controllers
{
    public class TomagotchiController : ITomagotchiController
    {
        private ITomagotchi _tomagotchi;
        private readonly IView _view;
        private string saveFileName = "save.json";

        public TomagotchiController(IView view, ITomagotchi tomagotchi)
        {
            _view = view;
            _tomagotchi = tomagotchi;
        }

        public async Task StartGame()
        {
            while (true)
            {
                bool exit = false;
                while (!exit && !_tomagotchi.IsCritical())
                {
                    _view.DisplayClear();

                    _tomagotchi.UpdateState();
                    _view.DrawTomagotchi(_tomagotchi.State);

                    _view.DisplayTomagotchiStatus(_tomagotchi.Name, _tomagotchi.Health, _tomagotchi.Hunger, _tomagotchi.Fatigue);

                    _view.DisplayActionMenu();
                    string choice = _view.GetUserInput();

                    switch (choice)
                    {
                        case "1":
                            _tomagotchi.Feed();
                            break;
                        case "2":
                            _tomagotchi.Play();
                            break;
                        case "3":
                            _view.DisplayClear();
                            _tomagotchi.State = TomagotchiStateEnum.Sleep;
                            _view.DrawTomagotchi(_tomagotchi.State);

                            await _tomagotchi.Sleep();
                            break;
                        case "4":
                            if (!File.Exists(saveFileName))
                            {
                                File.Create(saveFileName).Close();
                            }

                            await SaveGame(saveFileName);
                            break;
                        case "5":
                            _view.DisplayClear();
                            _view.DisplayMessage("Do you want to save your progress? (Y/N)");

                            if (_view.GetUserInput().ToLower() == "y")
                            {
                                if (!File.Exists(saveFileName))
                                {
                                    File.Create(saveFileName).Close();
                                }

                                await SaveGame(saveFileName);
                                await MainMenu();
                            }
                            else await MainMenu();
                            break;
                        default:
                            _view.DisplayMessage("Invalid choice. Please choose again.");
                            break;
                    }

                }

                if (_tomagotchi.IsCritical())
                {
                    _tomagotchi.State = TomagotchiStateEnum.Dead;

                    _view.DisplayClear();
                    _view.DrawTomagotchi(_tomagotchi.State);

                    _view.DisplayMessage("\nDo you want to play again? (Y/N)");

                    if (_view.GetUserInput().ToLower() == "y")
                    {
                        await MainMenu();
                    }

                    break;
                }

            }
        }

        public async Task SaveGame(string fileName)
        {
            try
            {
                string json = JsonSerializer.Serialize(_tomagotchi);

                File.WriteAllText(fileName, json);

                _view.DisplayClear();
                _view.DisplayMessage("Game saved successfully.");
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                _view.DisplayClear();
                _view.DisplayMessage($"Failed to save game: {ex.Message}");
                await Task.Delay(1000);
            }
        }

        public async Task LoadGame(string fileName)
        {
            try
            {
                string json = File.ReadAllText(fileName);

                var deserializedTomagotchi = JsonSerializer.Deserialize<Tomagotchi>(json);

                if (deserializedTomagotchi != null)
                {
                    _tomagotchi = deserializedTomagotchi;
                    _view.DisplayMessage("Game loaded successfully");
                    await StartGame();
                }
                else
                { 
                    _view.DisplayMessage("Failed to load save file. Creating a new game...");

                    await MainMenu();
                }
            }
            catch (Exception ex)
            {
                _view.DisplayMessage($"Failed to load game: {ex.Message}");
            }
        }

        public async Task MainMenu()
        {
            _view.DisplayClear();
            _view.DisplayMainMenu();
            string choice = _view.GetUserInput();

            switch (choice)
            {
                case "1":
                    await StartNewGame();
                    break;
                case "2":
                    await LoadGame(saveFileName);
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    _view.DisplayClear();
                    _view.DisplayMessage("Invalid choice. Please try again");

                    await Task.Delay(1000);
                    await MainMenu();
                    break;
            }
        }

        public async Task StartNewGame()
        {
            _view.DisplayClear();
            _view.DisplayMessage("Enter the name for your new pet: ");
            string petName = _view.GetUserInput();

            if (!string.IsNullOrWhiteSpace(petName))
            {
                _tomagotchi = new Tomagotchi(petName);
            }
            else
            {
                _view.DisplayClear();
                _view.DisplayMessage("Invalid name. Please try again");

                await Task.Delay(1000);
                await MainMenu();
            }

            

            await StartGame();
        }

    }
}
