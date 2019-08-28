using System.Collections;

namespace UGF.Initialize.Runtime
{
    public abstract class InitializeBaseAsync : InitializeBase, IInitializeAsync
    {
        private InitializeState m_state = new InitializeState();

        public IEnumerator InitializeAsync()
        {
            ValidateState(true);

            m_state.Initialize();

            yield return OnInitializeAsync();
        }

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
