using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _scope;

    public Action<int> ScopeChanger;

    public void Add()
    {
        _scope++;
        ScopeChanger?.Invoke(_scope);
    }

    public void Reset()
    {
        _scope = 0;
        ScopeChanger?.Invoke(_scope);
    }
}
