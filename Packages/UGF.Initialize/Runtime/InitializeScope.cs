using System;

namespace UGF.Initialize.Runtime
{
    public readonly struct InitializeScope : IDisposable
    {
        private readonly IInitialize m_target;

        public InitializeScope(IInitialize target)
        {
            m_target = target ?? throw new ArgumentNullException(nameof(target));

            if (!m_target.IsInitialized)
            {
                m_target.Initialize();
            }
        }

        public void Dispose()
        {
            if (m_target.IsInitialized)
            {
                m_target.Uninitialize();
            }
        }
    }
}
