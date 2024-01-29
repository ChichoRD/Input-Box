using UnityEngine;
using UnityEngine.Events;

namespace InputBox.Observable
{
    internal class InputObserver : MonoBehaviour
    {
        [SerializeReference]
        private Object _observableInputObject;
        private IObservableInput _observableInput;

        [field: SerializeField]
        public UnityEvent InputAppeared { get; set; }

        [field: SerializeField]
        public UnityEvent InputDisappeared { get; set; }

        private void Awake()
        {
            _observableInput = _observableInputObject as IObservableInput;

            _observableInput.InputRecieved += OnInputAppeared;
            _observableInput.InputExpired += OnInputDisappeared;
        }

        private void OnDestroy()
        {
            _observableInput.InputRecieved -= OnInputAppeared;
            _observableInput.InputExpired -= OnInputDisappeared;
        }

        private void OnInputAppeared(object sender, System.EventArgs e) => InputAppeared?.Invoke();

        private void OnInputDisappeared(object sender, System.EventArgs e) => InputDisappeared?.Invoke();
    }
}