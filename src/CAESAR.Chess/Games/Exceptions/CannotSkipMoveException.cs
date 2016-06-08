using System;
using CAESAR.Chess.Moves;

namespace CAESAR.Chess.Games.Exceptions
{
    /// <summary>
    ///     The exception that is thrown when an <seealso cref="IMove" /> cannot be skipped in a <seealso cref="IGame" />.
    /// </summary>
    public class CannotSkipMoveException : InvalidOperationException
    {
    }
}