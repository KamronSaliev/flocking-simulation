using UnityEngine;

public class ScaleCommand : ICommand
{
    private readonly Transform _transform;
    private Vector3 _initialScale;
    private float _maxScaleMultiplier;
    private float _scaleChangeSpeed;
    
    public ScaleCommand(Transform transform, float maxScaleMultiplier, float scaleChangeSpeed)
    {
        _transform = transform;
        _maxScaleMultiplier = maxScaleMultiplier;
        _scaleChangeSpeed = scaleChangeSpeed;
    }
    
    public void Execute()
    {
        _transform.localScale = Vector3.Lerp(_transform.localScale, Vector3.one * _maxScaleMultiplier, Time.deltaTime * _scaleChangeSpeed);
    }

    public void Revert()
    {
        _transform.localScale = Vector3.Lerp(_transform.localScale, Vector3.one * (-1 * _maxScaleMultiplier), Time.deltaTime * _scaleChangeSpeed);
    }
}
