using System;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public void Attack()
    {
        _weapon.Fire();
    }

    public void Reset()
    {
       _weapon.Reset();
    }
}