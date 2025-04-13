using UnityEngine;

public class Game : MonoBehaviour
{
    private Player _player;
    private MainMenu _mainMenu;
    private GameComponentRestarter _restarter;

    public void Initialize(Player player, MainMenu mainMenu, GameComponentRestarter restarter)
    {
        _player = player;
        _mainMenu = mainMenu;
        _restarter = restarter;
    }

    private void Start()
    {
        Time.timeScale = 0f;
        _mainMenu.OpenStartGameScreen();
    }

    private void OnEnable()
    {
        _mainMenu.PlayButtonClicked += StartGame;
        _mainMenu.RestartButtonClicked += StartGame;

        _player.Destoyed += EndGame;
    }

    private void OnDisable()
    {
        _mainMenu.PlayButtonClicked -= StartGame;
        _mainMenu.RestartButtonClicked += StartGame;

        _player.Destoyed -= EndGame;
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _restarter.Restart();
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        _mainMenu.OpenEndGameScreen();
    }
}
