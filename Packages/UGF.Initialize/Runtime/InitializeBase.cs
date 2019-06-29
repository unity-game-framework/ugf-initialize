namespace UGF.Initialize.Runtime
{
    public abstract class InitializeBase : IInitialize
    {
        public bool IsInitialized { get { return m_state.IsInitialized; } }

        private InitializeState m_state = new InitializeState();

        public void Initialize()
        {
            m_state.Initialize();

            OnPreInitialize();
            OnInitialize();
        }

        public void Uninitialize()
        {
            m_state.Uninitialize();

            OnUninitialize();
            OnPostUninitialize();
        }

        protected virtual void OnPreInitialize()
        {
        }

        protected virtual void OnInitialize()
        {
        }

        protected virtual void OnUninitialize()
        {
        }

        protected virtual void OnPostUninitialize()
        {
        }
    }
}
