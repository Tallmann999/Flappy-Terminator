using System.Collections;
using UnityEngine;

public class MeteoritSpawner : SpawnerBase<Meteorit>
{
    private void Start()
    {
        if (_current—oroutine != null)
        {
            StopCoroutine(_current—oroutine);
        }

        _current—oroutine = StartCoroutine(ObjectGenerator());
    }


    protected override void GreateNewPoolObject(out Meteorit meteorit)
    {
        meteorit = PoolObject.GetObject();
        meteorit.Destroyer -= OnReturnPoolObject;
        meteorit.Destroyer += OnReturnPoolObject;
        meteorit.transform.position = transform.position;
    }

    protected override void OnReturnPoolObject(Meteorit meteorit)
    {
        meteorit.Destroyer += OnReturnPoolObject;
        PoolObject.ReturnPoolObject(meteorit);
    }   
}
