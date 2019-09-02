using System;

namespace UGF.Initialize.Runtime
{
    public static partial class InitializeUtility
    {
        /// <summary>
        /// Validates state of the specified handler.
        /// </summary>
        /// <param name="handler">The initialize state handler to validate.</param>
        /// <param name="expected">The expected initialize state.</param>
        /// <param name="throws">The value that determines whether to throw exception on invalid validate result.</param>
        [Obsolete("ValidateState has been deprecated. Use another overload or extension method.")]
        public static bool ValidateState(IInitialize handler, bool expected, bool throws = true)
        {
            bool result = handler.IsInitialized == expected;

            if (!result && throws)
            {
                string header = handler.IsInitialized ? "An object already initialized." : "An object not initialized.";

                throw new InitializeStateException($"{header} ({handler}).");
            }

            return result;
        }
    }
}