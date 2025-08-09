using UnityEngine;

public class CubeRenderer : MonoBehaviour
{
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Colorer _colorer;
    [SerializeField] private ContactDetector _contactDetector;
    
    private bool _isColorChanged = false;

    private void OnEnable()
    {
        Init();
        _contactDetector.PlatformContacted += ChangeMaterial;
    }

    private void OnDisable()
    {
        _contactDetector.PlatformContacted -= ChangeMaterial;
    }

    private void Init()
    {
        _renderer.material = _defaultMaterial;
        _isColorChanged = false;
    }

    public void ChangeMaterial()
    {
        if (_isColorChanged == false)
        {
            _renderer.material = _colorer.GetMaterial();
            _isColorChanged = true;
        }
        _contactDetector.PlatformContacted -= ChangeMaterial;
    }
}
