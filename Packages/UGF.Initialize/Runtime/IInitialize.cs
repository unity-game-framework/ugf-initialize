namespace UGF.Initialize.Runtime
{
    /// <summary>
    /// Represents an object with initialize state.
    /// </summary>
    public interface IInitialize
    {
        /// <summary>
        /// Gets value that determines whether object is initialized.
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        /// Initializes this object.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Uninitializes this object.
        /// </summary>
        void Uninitialize();
    }
}
