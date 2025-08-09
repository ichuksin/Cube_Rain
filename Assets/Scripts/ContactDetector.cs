using System;

using UnityEngine;
using UnityEngine.Events;

public class ContactDetector : MonoBehaviour
{
    public event Action PlatformContacted;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Platform>(out _))
        {
            PlatformContacted?.Invoke();
        }
    }
}
