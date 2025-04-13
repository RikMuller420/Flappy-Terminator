using System;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    public event Action PlayButtonClicked;
    public event Action RestartButtonClicked;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
    }

    public void OpenStartGameScreen()
    {
        Debug.Log("OpenStartGameScreen");
        _startScreen.Open();
    }

    public void OpenEndGameScreen()
    {
        _endGameScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        PlayButtonClicked?.Invoke();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        RestartButtonClicked();
    }
}
