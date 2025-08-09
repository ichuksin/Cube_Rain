using UnityEngine;

public class LifeTimer : MonoBehaviour
{
    [SerializeField] private ContactDetector _contactDetector;
    [SerializeField] private Cube _cube;

    private float _minLifeTime = 2.0f;
    private float _maxLifeTime = 5.0f;

    private void OnEnable()
    {
        _contactDetector.Contacted += StartTimer;
    }

    private void OnDisable()
    {
        _contactDetector.Contacted -= StartTimer;
    }

    private void StartTimer()
    {
        Invoke(nameof(Die), Random.Range(_minLifeTime, _maxLifeTime));
    }

    private void Die()
    {
        gameObject.SetActive(false);    
    }
}
