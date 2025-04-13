using System;

public class StartScreen : MenuScreen
{
    public event Action PlayButtonClicked;

    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}
