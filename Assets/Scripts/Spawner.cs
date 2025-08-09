using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _maxRadius;
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private float _delay;
    [SerializeField] private Pool _pool;
    private List<Cube> _cubes = new List<Cube>();

    private void OnEnable()
    {
        foreach (Cube cube in _cubes)
            cube.Died += Release;
    }

    private void OnDisable()
    {
        foreach (Cube cube in _cubes)
            cube.Died -= Release;
    }

    private void Start()
    {
        InvokeRepeating (nameof(Spawn), _delay, _delay);
    }

    private void Release(Cube cube)
    {
        cube.Died -= Release;
        _cubes.Remove(cube);
        _pool.Release(cube);     
    }

    private void Spawn( )
    {
        Cube cube = _pool.GetObject();

        Vector3 newPosition = _spawnPosition + Random.insideUnitSphere * _maxRadius;

        cube.Init( newPosition);
        cube.Died += Release;
        _cubes.Add(cube);   
    }
}
