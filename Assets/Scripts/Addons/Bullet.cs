using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, ISpawnable<Bullet>
{


    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private int damage = 5;
    public event Action<Bullet> Destroyer;

    private Vector2 direction;

    public void Init(Vector2 dir)
    {
        direction = dir;
        Invoke(nameof(DestroyBullet), lifeTime);
    }

    private void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        CancelInvoke();
        Destroy(gameObject);
    }

    //[SerializeField] private float _speed;
    //[SerializeField] private float _lifeTime = 5f;
    //[SerializeField] private int _damage = 5;

    ////private Health _health;
    //private WaitForSeconds _waitForSeconds;
    //private Coroutine _coroutine;
    //private bool _isReturned;

    //public event Action<Bullet> Destroyer;

    //private void FixedUpdate()
    //{
    //    Move();
    //}

    //public void Move()
    //{
    //    transform.Translate(Vector2.left * Time.deltaTime * _speed);
    //}

    //private void Awake()
    //{
    //    _isReturned = false;
    //    //_health = GetComponent<Health>();
    //}

    //private void Start()
    //{
    //    if (_coroutine != null)
    //    {
    //        StopCoroutine(LifecycleRoutine());
    //    }

    //    _coroutine = StartCoroutine(LifecycleRoutine());
    //}

    //private IEnumerator LifecycleRoutine()// прописать логику жизни 
    //{
    //    _waitForSeconds = new WaitForSeconds(_lifeTime);
    //    yield return _waitForSeconds;
    //    ReturnToPool();
    //}

    //private void ReturnToPool()
    //{
    //    if (_isReturned)
    //        return;

    //    _isReturned = true;
    //    Destroyer?.Invoke(this);
    //}
}
