using InputBox.Readable;
using UnityEngine;

public class AxisProjectorInputReadable : MonoBehaviour,
    IInputReadable<float>, IInputReadable<Vector2>, IInputReadable<Vector3>, IInputReadable<Vector4>
{
    [SerializeReference]
    private Object _inputReadableObject;

    [field: SerializeField]
    public Vector4 ProjectionAxis { get; set; } = Vector3.up;
    [SerializeField] private bool _renormalize = true;

    private IInputReadable<float> _inputReadableFloat;
    private IInputReadable<Vector2> _inputReadableVector2;
    private IInputReadable<Vector3> _inputReadableVector3;
    private IInputReadable<Vector4> _inputReadableVector4;

    private void Awake()
    {
        _inputReadableFloat = _inputReadableObject as IInputReadable<float>;
        _inputReadableVector2 = _inputReadableObject as IInputReadable<Vector2>;
        _inputReadableVector3 = _inputReadableObject as IInputReadable<Vector3>;
        _inputReadableVector4 = _inputReadableObject as IInputReadable<Vector4>;
    }

    public float Get()
    {
        Vector3 projectedInput = Vector3.Project(new Vector3(_inputReadableFloat.Get(), 0.0f, 0.0f), ProjectionAxis);
        return _renormalize ? Mathf.Sign(projectedInput.x) : projectedInput.x;
    }

    Vector2 IInputReadable<Vector2>.Get()
    {
        Vector2 projectedInput = Vector3.Project(_inputReadableVector2.Get(), ProjectionAxis);
        return _renormalize ? projectedInput.normalized : projectedInput;
    }

    Vector3 IInputReadable<Vector3>.Get()
    {
        Vector3 projectedInput = Vector3.Project(_inputReadableVector3.Get(), ProjectionAxis);
        return _renormalize ? projectedInput.normalized : projectedInput;
    }

    Vector4 IInputReadable<Vector4>.Get()
    {
        Vector4 projectedInput = Vector4.Project(_inputReadableVector4.Get(), ProjectionAxis);
        return _renormalize ? projectedInput.normalized : projectedInput;
    }
}
