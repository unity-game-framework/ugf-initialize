using System.Threading.Tasks;

namespace UGF.Initialize.Runtime
{
    public class InitializableAsync : Initializable, IInitializeAsync
    {
        public bool IsInitializedAsync { get { return m_state; } }

        private InitializeState m_state;

        protected virtual Task OnInitializeAsync()
        {
            return Task.CompletedTask;
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            if (m_state)
            {
                m_state = m_state.Uninitialize();
            }
        }

        public Task InitializeAsync()
        {
            m_state = m_state.Initialize();

            return OnInitializeAsync();
        }
    }
}
