using System.Collections;

namespace UGF.Initialize.Runtime
{
    /// <summary>
    /// Represents an object with initialize state and additional state which should be initialized asynchronously.
    /// </summary>
    public interface IInitializeAsync : IInitialize
    {
        /// <summary>
        /// Gets coroutine for additional asynchronous initialize, which must be evaluated.
        /// </summary>
        IEnumerator InitializeAsync();
    }
}
