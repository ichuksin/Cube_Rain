using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    [SerializeField]  private Queue<Cube> _cubes = new Queue<Cube>();

    public Cube GetObject()
    {
        Cube cube;
        
        if (_cubes.Count == 0)
            cube = Instantiate(_prefab);
        else
            cube = _cubes.Dequeue();

        return cube;
    }

    public void Release(Cube cube)
    {
        _cubes.Enqueue(cube);
    }
}
