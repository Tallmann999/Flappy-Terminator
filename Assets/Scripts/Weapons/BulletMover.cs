using System;
using UnityEngine;

public class BulletMover : MonoBehaviour, IMoveble
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _direction;

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(_direction * Time.deltaTime * _speed);
    }

    internal void SetDirection(Vector2 direction)
    {
        throw new NotImplementedException();
    }

    //public void Reset()
    //{
    //    transform.position = Vector2.zero;
    //}
}
