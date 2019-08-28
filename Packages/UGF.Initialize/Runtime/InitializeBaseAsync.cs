using System.Collections;

namespace UGF.Initialize.Runtime
{
    /// <summary>
    /// Represents an object with initialize state and additional state which should be initialized asynchronously.
    /// </summary>
    public abstract class InitializeBaseAsync : InitializeBase, IInitializeAsync
    {
        private InitializeState m_state = new InitializeState();

        public IEnumerator InitializeAsync()
        {
            ValidateState(true);

            m_state.Initialize();

            yield return OnInitializeAsync();
        }

        /// <summary>
        /// Invokes on async initialization.
        /// </summary>
        protected virtual IEnumerator OnInitializeAsync()
        {
            yield break;
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_state.Uninitialize();
        }
    }
}
