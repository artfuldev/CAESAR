namespace CAESAR.Chess.Core
{
    /// <summary>
    ///     Represents an object that is cloneable
    /// </summary>
    public interface ICloneable
    {
        /// <summary>
        ///     Return a clone of the current object
        /// </summary>
        /// <returns>An <seealso cref="object" /> that is the clone of the current object.</returns>
        object Clone();
    }
}