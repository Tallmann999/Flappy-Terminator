using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _direction;

    private void Update()
    {
        Move();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void Move()
    {
        transform.Translate(_direction * Time.deltaTime * _speed, Space.World);
    }
}