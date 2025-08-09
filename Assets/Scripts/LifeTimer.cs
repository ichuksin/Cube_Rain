using System;
using System.Collections;
using UnityEngine;

public class LifeTimer : MonoBehaviour
{
    [SerializeField] private ContactDetector _contactDetector;

    private float _minLifeTime = 2.0f;
    private float _maxLifeTime = 5.0f;

    public event Action TimerEnded;
    
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
        StartCoroutine(CountDownTime(delay));
    }

    private IEnumerator CountDownTime(float delay) 
    { 
        var wait = new WaitForSeconds(delay);
        yield return wait;
        TimerEnded?.Invoke();
        yield break;
    }
}
