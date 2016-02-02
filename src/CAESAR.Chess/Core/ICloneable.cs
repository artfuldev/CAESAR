namespace CAESAR.Chess.Core
{
    public interface ICloneable<out T>
    {
        T Clone();
    }

    public interface ICloneable : ICloneable<object>
    {
    }
}