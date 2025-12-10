using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour, IMoveble
{
    [SerializeField] private float _speed;
    //[SerializeField] private float _tapForce;

    private float _yOffset = 4f;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _startPosition;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
    } 

    public void Move()
    {
        _rigidbody2D.linearVelocity = Vector2.up * _speed;

        if (transform.position.y >= _yOffset)
        {
            _rigidbody2D.linearVelocity = Vector2.zero; 
        }
    }

    public void Reset()
    {
        transform.position = _startPosition;
        //transform.rotation = _startRotation;
        _rigidbody2D.linearVelocity = Vector2.zero;
    }
}
