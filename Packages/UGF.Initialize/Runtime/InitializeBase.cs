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
        public bool IsInitialized { get { return m_state; } }

        public event InitializeHandler Initialized;
        public event InitializeHandler Uninitialized;

        private InitializeState m_state;

        /// <summary>
        /// Initializes this object.
        /// </summary>
        public void Initialize()
        {
            m_state = m_state.Initialize();

            OnPreInitialize();
            OnInitialize();
            OnPostInitialize();

            Initialized?.Invoke(this);
        }

        /// <summary>
        /// Uninitializes this object.
        /// </summary>
        public void Uninitialize()
        {
            m_state = m_state.Uninitialize();

            OnPreUninitialize();
            OnUninitialize();
            OnPostUninitialize();

            Uninitialized?.Invoke(this);
        }

        /// <summary>
        /// Validates state of this object.
        /// </summary>
        /// <param name="expected">The expected initialize state.</param>
        /// <param name="throws">The value that determines whether to throw exception on invalid validate result.</param>
        protected bool ValidateState(bool expected, bool throws = true)
        {
            return m_state.ValidateState(expected, throws);
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
        /// Invokes after initialization.
        /// </summary>
        protected virtual void OnPostInitialize()
        {
        }

        /// <summary>
        /// Invokes before uninitialization.
        /// </summary>
        protected virtual void OnPreUninitialize()
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
