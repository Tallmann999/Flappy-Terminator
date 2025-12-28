using System;

public class EndScreenGame : Window
{
    public event Action RestartButtonClicked;

    public override void Close()
    {
        WindowsGroup.alpha = 0f;
        ActionButton.interactable = false;
        WindowsGroup.blocksRaycasts = false;
    }

    public override void Open()
    {
        WindowsGroup.alpha = 1f;
        ActionButton.interactable = true;
        WindowsGroup.blocksRaycasts = true;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}