using System.Collections;

namespace UGF.Initialize.Runtime
{
    /// <summary>
    /// Represents an object with initialize state and additional state which should be initialized asynchronously.
    /// </summary>
    public abstract class InitializeBaseAsync : InitializeBase, IInitializeAsync
    {
        public bool IsAsyncInitialized { get { return m_initializeAsyncState.IsInitialized && m_initializeAsyncRoutine == null; } }
        public bool IsAsyncInProgress { get { return m_initializeAsyncRoutine != null; } }

        private InitializeState m_initializeAsyncState = new InitializeState();
        private IEnumerator m_initializeAsyncRoutine;

        public IEnumerator InitializeAsync()
        {
            ValidateState(true);

            m_initializeAsyncState.Initialize();
            m_initializeAsyncRoutine = WaitForOnInitializeAsync();

            return m_initializeAsyncRoutine;
        }

        /// <summary>
        /// Invoked on async initialization.
        /// </summary>
        protected virtual IEnumerator OnInitializeAsync()
        {
            yield break;
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_initializeAsyncState.Uninitialize();

            InitializeUtility.ValidateState(false, IsAsyncInProgress, nameof(IsAsyncInProgress));
        }

        private IEnumerator WaitForOnInitializeAsync()
        {
            yield return OnInitializeAsync();

            m_initializeAsyncRoutine = null;
        }
    }
}
