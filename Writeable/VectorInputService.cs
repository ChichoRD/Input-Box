using InputBox.Readable;
using UnityEngine;

namespace InputBox.Writeable
{
    internal class VectorInputService : MonoBehaviour,
        IInputWriteable<float>, IInputWriteable<Vector2>, IInputWriteable<Vector3>, IInputWriteable<Vector4>,
        IInputReadable<float>, IInputReadable<Vector2>, IInputReadable<Vector3>, IInputReadable<Vector4>
    {
        private Vector4 _input;

        public float Get() => _input.x;
        Vector2 IInputReadable<Vector2>.Get() => _input;
        Vector3 IInputReadable<Vector3>. Get() => _input;
        Vector4 IInputReadable<Vector4>. Get() => _input;

        public bool TrySet(float input)
        {
            _input.x = input;
            return true;
        }

        public bool TrySet(Vector2 input)
        {
            _input = input;
            return true;
        }

        public bool TrySet(Vector3 input)
        {
            _input = input;
            return true;
        }

        public bool TrySet(Vector4 input)
        {
            _input = input;
            return true;
        }
    }
}