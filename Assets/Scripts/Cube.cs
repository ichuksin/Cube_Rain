using System;

using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeRenderer _cubeRenderer;
    [SerializeField] private LifeTimer _lifeTimer;

    public CubeRenderer CubeRenderer => _cubeRenderer;
    public LifeTimer LifeTimer => _lifeTimer;

    
    public void Init(Vector3 position)
    {
        transform.position = position;
        Enable();
    }

    private void Enable()
    {
        gameObject.SetActive(true);
    }
}
