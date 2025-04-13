using System;
using UnityEngine;

public class GroundCollisionHandler : MonoBehaviour
{
    public event Action CollisionDetected;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out _))
        {
            CollisionDetected?.Invoke();
        }
    }
}
