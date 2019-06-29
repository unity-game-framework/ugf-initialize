namespace UGF.Initialize.Runtime
{
    /// <summary>
    /// Represents an object with initialize state.
    /// </summary>
    public abstract class InitializeBase : IInitialize
    {
        /// <summary>
        /// Gets value that determines whether object is initialized.
        /// </summary>
        public bool IsInitialized { get { return m_state.IsInitialized; } }

        private InitializeState m_state = new InitializeState();

        /// <summary>
        /// Initializes this object.
        /// </summary>
        public void Initialize()
        {
            m_state.Initialize();

            OnPreInitialize();
            OnInitialize();
        }

        /// <summary>
        /// Uninitializes this object.
        /// </summary>
        public void Uninitialize()
        {
            m_state.Uninitialize();

            OnUninitialize();
            OnPostUninitialize();
        }

        /// <summary>
        /// Invokes before initialization.
        /// </summary>
        protected virtual void OnPreInitialize()
        {
        }

        /// <summary>
        /// Invokes on initialization.
        /// </summary>
        protected virtual void OnInitialize()
        {
        }

        /// <summary>
        /// Invokes on uninitialization.
        /// </summary>
        protected virtual void OnUninitialize()
        {
        }

        /// <summary>
        /// Invokes after uninitialization.
        /// </summary>
        protected virtual void OnPostUninitialize()
        {
        }
    }
}
