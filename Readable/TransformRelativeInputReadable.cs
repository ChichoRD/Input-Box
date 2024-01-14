﻿using InputBox.Readable;
using UnityEngine;

public class TransformRelativeInputReadable : MonoBehaviour,
    IInputReadable<float>, IInputReadable<Vector2>, IInputReadable<Vector3>, IInputReadable<Vector4>
{
    [SerializeReference]
    private Object _inputReadableObject;

    [SerializeField]
    private Transform _transformation = null;

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

    public float Get() => _transformation.TransformVector(new Vector3(_inputReadableFloat.Get(), 0.0f, 0.0f)).x;

    Vector2 IInputReadable<Vector2>.Get() => _transformation.TransformVector(_inputReadableVector2.Get());

    Vector3 IInputReadable<Vector3>.Get() => _transformation.TransformVector(_inputReadableVector3.Get());

    Vector4 IInputReadable<Vector4>.Get() => _transformation.TransformVector(_inputReadableVector4.Get());
}