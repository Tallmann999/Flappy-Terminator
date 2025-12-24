using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _actionButton;

    public CanvasGroup CanvasGroup => _canvasGroup;
    public Button ActionButton => _actionButton;

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {       
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();
}
