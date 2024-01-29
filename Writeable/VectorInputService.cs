using InputBox.Observable;
using InputBox.Readable;
using System;
using UnityEngine;

namespace InputBox.Writeable
{
    internal class VectorInputService : MonoBehaviour,
        IInputWriteable<float>, IInputWriteable<Vector2>, IInputWriteable<Vector3>, IInputWriteable<Vector4>,
        IInputReadable<float>, IInputReadable<Vector2>, IInputReadable<Vector3>, IInputReadable<Vector4>,
        IObservableInput
    {
        private Vector4 _input;
        public Vector4 Input
        {
            get => _input;
            set
            {
                _input = value;
                InputRecieved?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler InputRecieved;
        public event EventHandler InputExpired;
        public float Get() => Input.x;
        Vector2 IInputReadable<Vector2>.Get() => Input;
        Vector3 IInputReadable<Vector3>. Get() => Input;
        Vector4 IInputReadable<Vector4>. Get() => Input;

        public bool TrySet(float input)
        {
            Input = new Vector4(input, Input.y, Input.z, Input.w);
            return true;
        }

        public bool TrySet(Vector2 input)
        {
            Input = input;
            return true;
        }

        public bool TrySet(Vector3 input)
        {
            Input = input;
            return true;
        }

        public bool TrySet(Vector4 input)
        {
            Input = input;
            return true;
        }
    }
}