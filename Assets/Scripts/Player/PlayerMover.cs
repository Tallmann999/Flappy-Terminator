using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour, IMoveble
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;

    private Rigidbody2D _rigidbody;
    private Vector3 _startposition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startposition = transform.position;
    }
 

    public void Move()
    {
        _rigidbody.linearVelocity = new Vector2(_speed, _tapForce);
    }
}
