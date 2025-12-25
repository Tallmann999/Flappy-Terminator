using System;
using UnityEngine;

public class EndScreenGame : Window
{
    public event Action RestartButtonClicked;
    public override void Close()
    {
        WindowsGroup.alpha = 0f;
        ActionButton.interactable = false;
    }

    public override void Open()
    {
        WindowsGroup.alpha = 1f;
        ActionButton.interactable = true;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}
