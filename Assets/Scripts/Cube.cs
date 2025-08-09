using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    [SerializeField] private CubeRenderer _cubeRenderer;

    public CubeRenderer CubeRenderer => _cubeRenderer;

    public event UnityAction<Cube> Died;
    
    public void Init(Vector3 position)
    {
        transform.position = position;
        Enable();
    }

    private void OnDisable()
    {
        Died?.Invoke(this);
    }

    private void Enable()
    {
        gameObject.SetActive(true);
    }
}
