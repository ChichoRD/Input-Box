using System;

namespace InputBox.Observable
{
    public interface IObservableInput
    {
        event EventHandler InputAppeared;
        event EventHandler InputDisappeared;
    }
}