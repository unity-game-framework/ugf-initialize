using System.Collections;

namespace UGF.Initialize.Runtime
{
    /// <summary>
    /// Represents an object with initialize state and additional state which should be initialized asynchronously.
    /// </summary>
    public interface IInitializeAsync : IInitialize
    {
        /// <summary>
        /// Gets the value that determines whether async initialization has been called and completed.
        /// </summary>
        bool IsAsyncInitialized { get; }

        /// <summary>
        /// Gets the value that determines whether async initialization in progress.
        /// </summary>
        bool IsAsyncInProgress { get; }

        /// <summary>
        /// Gets coroutine for additional asynchronous initialize, which must be evaluated.
        /// </summary>
        IEnumerator InitializeAsync();
    }
}
