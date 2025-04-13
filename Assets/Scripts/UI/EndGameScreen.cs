using System;

public class EndGameScreen : MenuScreen
{
    public event Action RestartButtonClicked;

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}
