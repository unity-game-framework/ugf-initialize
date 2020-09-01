using System;

namespace UGF.Initialize.Runtime
{
    /// <summary>
    /// Represents error that occur on invalid initialize state change or state validate.
    /// </summary>
    public sealed class InitializeStateException : Exception
    {
        public InitializeStateException() : base("Invalid initialize state.")
        {
        }

        public InitializeStateException(string message) : base(message)
        {
        }
    }
}
