using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _direction;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_direction * Time.deltaTime * _speed);
    }
}