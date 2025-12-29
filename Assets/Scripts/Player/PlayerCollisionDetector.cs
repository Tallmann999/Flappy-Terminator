using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollisionDetector : MonoBehaviour
{
    public event Action<IInteractable> CollisionDetection;

    private void OnValidate()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable iInteractable))
            CollisionDetection?.Invoke(iInteractable);
    }
}