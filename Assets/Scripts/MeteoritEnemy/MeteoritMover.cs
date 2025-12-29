using UnityEngine;

public class MeteoritMover : MonoBehaviour
{
    [SerializeField] private float _minSpeed = 4f;
    [SerializeField] private float _maxSpeed = 7f;

    [SerializeField] private float _minRotationSpeed = 50f;
    [SerializeField] private float _maxRotationSpeed = 150f;

    [SerializeField] private float _minScale = 0.5f;
    [SerializeField] private float _maxScale = 1.5f;

    private float _speed;
    private float _rotationSpeed;

    private void Awake()
    {
        InitializeRandomParameters();
    }

    private void Update()
    {
        MoveAndRotate();
    }

    private void InitializeRandomParameters()
    {
        _speed = Random.Range(_minSpeed, _maxSpeed);
        _rotationSpeed = Random.Range(_minRotationSpeed, _maxRotationSpeed);
        float scale = Random.Range(_minScale, _maxScale);
        transform.localScale = Vector3.one * scale;
    }

    private void MoveAndRotate()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
    }
}