using UnityEngine;
using UnityEngine.Events;

public class ContactDetector : MonoBehaviour
{
    public event UnityAction Contacted;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Platform>(out _))
        {
            Contacted?.Invoke();
        }
    }
}
