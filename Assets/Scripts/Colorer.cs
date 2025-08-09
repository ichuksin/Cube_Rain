using UnityEngine;

public class Colorer : MonoBehaviour
{
    [SerializeField] private Material[] _materials;
    
    public Material GetMaterial()
    {
        return _materials[Random.Range(0, _materials.Length)];
    }
}
