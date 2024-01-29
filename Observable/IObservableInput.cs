using System;

namespace InputBox.Observable
{
    public interface IObservableInput
    {
        event EventHandler InputRecieved;
        event EventHandler InputExpired;
    }
}