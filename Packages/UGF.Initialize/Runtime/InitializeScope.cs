using System;

namespace UGF.Initialize.Runtime
{
    public struct InitializeScope : IDisposable
    {
        private readonly IInitialize m_target;

        public InitializeScope(IInitialize target)
        {
            m_target = target;

            if (!m_target.IsInitialized)
            {
                m_target.Initialize();
            }
        }

        public void Dispose()
        {
            m_target.Uninitialize();
        }
    }
}
