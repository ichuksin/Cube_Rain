using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _maxRadius;
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private float _delay;
    [SerializeField] private Pool _pool;
    
    private void Start()
    {
        StartCoroutine(SpawnTimer(_delay));
    }

    private void Release(Cube cube)
    {
        cube.CubeDied -= Release;
        _pool.Release(cube);     
    }

    private void Spawn( )
    {
        Cube cube = _pool.GetObject();

        Vector3 newPosition = _spawnPosition + Random.insideUnitSphere * _maxRadius;

        cube.Init( newPosition);
        cube.CubeDied += Release;
    }

    private IEnumerator SpawnTimer(float delay)
    {
        var wait = new WaitForSeconds(delay);
        while (enabled)
        {
            Spawn();
            yield  return wait;
        }
    }
}
