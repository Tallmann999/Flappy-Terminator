using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MeteoritChanger : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float minSpeed = 1f;
    [SerializeField] private float maxSpeed = 3f;

    [Header("Rotation")]
    [SerializeField] private float minRotationSpeed = 50f;
    [SerializeField] private float maxRotationSpeed = 150f;

    [Header("Scale")]
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 1.5f;

    private float speed;
    private float rotationSpeed;

    private void Awake()
    {
        // случайная скорость движения
        speed = Random.Range(minSpeed, maxSpeed);

        // случайная скорость вращения
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        // случайный размер
        float scale = Random.Range(minScale, maxScale);
        transform.localScale = Vector3.one * scale;
    }

    private void Update()
    {
        Changer();
    }

    private void Changer()
    {
        // движение
        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);

        // вращение
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    //private float _minValue = 2f;
    //private float _maxValue = 5f;
    //private Vector3 _targetEuler;

    //private void Update()
    //{
    //    Move();
    //}

    //public void Move()
    //{
    //    transform.Translate(Vector2.left * Time.deltaTime * GetRandomValue());
    //    Quaternion targetRotation = Quaternion.Euler(_targetEuler);
    //    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 50f);
    //}

    //private float GetRandomValue()
    //{
    //    float randomValue = Random.Range(_minValue,_maxValue+1);
    //    return randomValue;
    //}
}
