namespace UGF.Initialize.Runtime
{
    public static class InitializeExtensions
    {
        public static bool ValidateState(this IInitialize handler, bool expected, bool throws = true)
        {
            return InitializeUtility.ValidateState(expected, handler, throws);
        }
    }
}
