using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TextMeshProUGUI  _scope;

    private int _startScopeCount = 0;

    private void OnEnable()
    {
        _scope.text = _startScopeCount.ToString();
        _scoreCounter.ScopeChanger += OnScopeChanger;
    }

    private void OnDisable()
    {
        _scoreCounter.ScopeChanger -= OnScopeChanger;        
    }

    private void OnScopeChanger(int scope)
    {
        _scope.text= scope.ToString();
    }
}
