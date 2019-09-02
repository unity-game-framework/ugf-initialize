using System;

namespace UGF.Initialize.Runtime
{
    /// <summary>
    /// Provides utilities to work with initialize.
    /// </summary>
    public static partial class InitializeUtility
    {
        public static bool ValidateState(bool expected, IInitialize handler, bool throws = true)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            return ValidateState(expected, handler.IsInitialized, handler.ToString(), throws);
        }

        public static bool ValidateState(bool expected, InitializeState state, bool throws = true)
        {
            return ValidateState(expected, state.IsInitialized, state.Name, throws);
        }

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
