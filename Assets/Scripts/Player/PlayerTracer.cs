using UnityEngine;

public class PlayerTracer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _xOffset;

    private Vector3 _position;

    private void LateUpdate()
    {
        _position = transform.position;
        _position.x = _player.transform.position.x + _xOffset;
        transform.position = _position;
    }
}