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

        public TomagotchiController(ITomagotchi tomagotchi, IView view)
        {
            _tomagotchi = tomagotchi;
            _view = view;
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
                            exit = true;
                            break;
                        case "5":
                            if (!File.Exists(saveFileName))
                            {
                                File.Create(saveFileName).Close();
                            }

                            SaveGame(saveFileName);
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
                    string playAgainChoice = _view.GetUserInput().ToLower();

                    if (playAgainChoice == "y")
                    {
                        await ResetGame();
                    }

                    break;
                }
                else if (exit == true)
                {
                    _view.DisplayClear();

                    _view.DisplayMessage("\nDo you want to play again? (Y/N)");
                    string playAgainChoice = _view.GetUserInput().ToLower();

                    if (playAgainChoice == "y")
                    {
                        await ResetGame();
                    }
                    else
                    {
                        _view.DisplayClear();
                        Console.WriteLine("Goodbye! Thanks for playing!");
                    }
                    break;
                }

            }
        }

        private async Task ResetGame()
        {
            _view.DisplayClear();
            Console.Write("Enter the name for your new pet: ");
            string petName = _view.GetUserInput();

            _tomagotchi = new Tomagotchi(petName);

            await StartGame();
        }

        private void SaveGame(string fileName)
        {
            try
            {
                // Сериализуем объект _tomagotchi в формат JSON
                string json = JsonSerializer.Serialize(_tomagotchi);

                // Записываем сериализованные данные в файл
                File.WriteAllText(fileName, json);

                _view.DisplayMessage("Game saved successfully.");
            }
            catch (Exception ex)
            {
                _view.DisplayMessage($"Failed to save game: {ex.Message}");
            }
        }

        public async void LoadGame(string fileName)
        {
            try
            {
                string json = File.ReadAllText(fileName);

                var deserializedTomagotchi = JsonSerializer.Deserialize<Tomagotchi>(json);

                if (deserializedTomagotchi != null)
                {
                    _tomagotchi = deserializedTomagotchi;
                    _view.DisplayMessage("Game loaded successfully");
                }
                else
                { 
                    _view.DisplayMessage("Failed to load save file. Creating a new game...");
                    
                    await ResetGame();
                }
            }
            catch (Exception ex)
            {
                _view.DisplayMessage($"Failed to load game: {ex.Message}");
            }
        }

    }
}
