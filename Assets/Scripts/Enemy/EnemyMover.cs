using UnityEngine;

public class EnemyMover : MonoBehaviour 
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * Time.deltaTime * _speed);
    }

    public void Reset()
    {
        transform.position = Vector2.zero;
    }
}