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

        private bool m_state;

        /// <summary>
        /// Initializes this object.
        /// </summary>
        public void Initialize()
        {
            if (m_state)
            {
                throw new InitializeStateException($"An object already initialized ({this}).");
            }

            m_state = true;

            OnPreInitialize();
            OnInitialize();
        }

        /// <summary>
        /// Uninitializes this object.
        /// </summary>
        public void Uninitialize()
        {
            if (!m_state)
            {
                throw new InitializeStateException($"An object already uninitialized ({this}).");
            }

            m_state = false;

            OnUninitialize();
            OnPostUninitialize();
        }

        protected bool ValidateState(bool expected, bool throws = true)
        {
            return InitializeUtility.ValidateState(this, expected, throws);
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
