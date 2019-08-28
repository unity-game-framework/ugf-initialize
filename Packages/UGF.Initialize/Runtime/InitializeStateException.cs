using System;

namespace UGF.Initialize.Runtime
{
    public sealed class InitializeStateException : Exception
    {
        public InitializeStateException(string message) : base(message)
        {
        }
    }
}
