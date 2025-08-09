using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeRenderer _cubeRenderer;
    [SerializeField] private LifeTimer _lifeTimer;

    public CubeRenderer CubeRenderer => _cubeRenderer;
    
    public event Action<Cube> CubeDied;

    public void Init(Vector3 position)
    {
        transform.position = position;
        Enable();
    }

    private void OnEnable()
    {
        _lifeTimer.TimerEnded += Die;
    }

    private void OnDisable()
    {
        _lifeTimer.TimerEnded -= Die;
    }

    private void Enable()
    {
        gameObject.SetActive(true);
    }

    private void Die()
    {
        CubeDied?.Invoke(this);
        gameObject.SetActive(false);
    }
}
