using System;
using System.Collections;
using UnityEngine;

public class LifeTimer : MonoBehaviour
{
    [SerializeField] private ContactDetector _contactDetector;
    [SerializeField] private Cube _cube;

    private float _minLifeTime = 2.0f;
    private float _maxLifeTime = 5.0f;

    public event Action<Cube> CubeDied;
    private void OnEnable()
    {
        _contactDetector.PlatformContacted += StartTimer;
    }

    private void OnDisable()
    {
        _contactDetector.PlatformContacted -= StartTimer;
    }

    private void StartTimer()
    {
        float delay = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);
        StartCoroutine(Timer(delay));
    }

    private IEnumerator Timer(float delay) 
    { 
        var wait = new WaitForSeconds(delay);
        yield return wait;
        CubeDied?.Invoke(_cube);
        Die();
        yield break;
    }
    private void Die()
    {
        gameObject.SetActive(false);    
    }
}
