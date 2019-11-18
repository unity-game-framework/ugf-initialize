using System;

namespace UGF.Initialize.Runtime
{
    /// <summary>
    /// Provides utilities to work with initialize.
    /// </summary>
    public static partial class InitializeUtility
    {
        /// <summary>
        /// Validates state of the specified handler.
        /// </summary>
        /// <param name="expected">The expected initialize state.</param>
        /// <param name="handler">The initialize state handler to validate.</param>
        /// <param name="throws">The value that determines whether to throw exception on invalid validate result.</param>
        public static bool ValidateState(bool expected, IInitialize handler, bool throws = true)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            return ValidateState(expected, handler.IsInitialized, handler.ToString(), throws);
        }

        /// <summary>
        /// Validates state of the specified handler.
        /// </summary>
        /// <param name="expected">The expected initialize state.</param>
        /// <param name="state">The actual initialize state.</param>
        /// <param name="throws">The value that determines whether to throw exception on invalid validate result.</param>
        public static bool ValidateState(bool expected, InitializeState state, bool throws = true)
        {
            return ValidateState(expected, state, null, throws);
        }

        /// <summary>
        /// Validates state of the specified handler.
        /// </summary>
        /// <param name="expected">The expected initialize state.</param>
        /// <param name="actual">The actual initialize state.</param>
        /// <param name="name">The name of the state.</param>
        /// <param name="throws">The value that determines whether to throw exception on invalid validate result.</param>
        public static bool ValidateState(bool expected, bool actual, string name = null, bool throws = true)
        {
            if (string.IsNullOrEmpty(name)) name = "State";

            bool result = expected == actual;

            if (!result && throws)
            {
                string message = actual ? $"An '{name}' already initialized." : $"An '{name}' not initialized.";

                throw new InitializeStateException(message);
            }

            return result;
        }
    }
}
