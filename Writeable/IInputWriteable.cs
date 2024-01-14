namespace InputBox.Writeable
{
    public interface IInputWriteable<in TInput>
    {
        bool TrySet(TInput input);
    }
}