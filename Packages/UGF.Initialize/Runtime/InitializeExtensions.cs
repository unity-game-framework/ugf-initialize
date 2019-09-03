namespace UGF.Initialize.Runtime
{
    public static class InitializeExtensions
    {
        /// <summary>
        /// Validates state of the specified handler.
        /// </summary>
        /// <param name="handler">The initialize state handler to validate.</param>
        /// <param name="expected">The expected initialize state.</param>
        /// <param name="throws">The value that determines whether to throw exception on invalid validate result.</param>
        public static bool ValidateState(this IInitialize handler, bool expected, bool throws = true)
        {
            return InitializeUtility.ValidateState(expected, handler, throws);
        }
    }
}
