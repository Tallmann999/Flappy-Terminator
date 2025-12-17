using System;
using UnityEngine;

public  class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue; 
    [SerializeField] private float _minValue; 
    [SerializeField] private float _startValue; 
    [SerializeField] private float _currentValue;

    private bool _isDie;

    public event Action Hit;
    public event Action<bool> Die;
    public event Action<float> CurrentHealth;

    public float CurrentValue => _currentValue;
    public float MaxValue=>_maxValue;

    private void Awake()
    {
      _currentValue = _startValue;    
    }

    public void TakeDamage(int damage)
    {
        Hit?.Invoke();
        DeclineValue(damage);
        CurrentHealth?.Invoke(_currentValue);

        if (_currentValue <= 0)
        {
            _isDie = true;
            Die?.Invoke(_isDie);
        }
    }

    public void DeclineValue(float amount)
    {
        if (amount < 0)
            return;

        _currentValue = Mathf.Max(_currentValue - amount, _minValue);
    }

    public void AddValue(float amount)
    {
        if (amount < 0)
            return;

        _currentValue = Mathf.Min(_currentValue + amount, _maxValue);
        CurrentHealth?.Invoke(_currentValue);
    }

    public bool IsAlive()
    {
        if (!_isDie)
        {
            return true;
        }

        return false;
    }
}
