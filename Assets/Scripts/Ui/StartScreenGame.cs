using System;
using UnityEngine;

public class StartScreenGame : Window
{
    public event Action PlayButtonClicked;
    public override void Close()
    {
        WindowsGroup.alpha = 0f;
        ActionButton.interactable = false;
    }

    public override void Open()
    {
        ActionButton.interactable = true;
        WindowsGroup.alpha = 1f;
    }

    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}
