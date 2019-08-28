namespace UGF.Initialize.Runtime
{
    public static class InitializeUtility
    {
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
