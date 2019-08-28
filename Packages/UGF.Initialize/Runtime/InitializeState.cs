namespace UGF.Initialize.Runtime
{
    /// <summary>
    /// Represents mutable initialize state.
    /// </summary>
    public struct InitializeState : IInitialize
    {
        public bool IsInitialized { get { return m_state; } }

        private bool m_state;

        public void Initialize()
        {
            if (m_state)
            {
                throw new InitializeStateException("An state already initialized.");
            }

            m_state = true;
        }

        public void Uninitialize()
        {
            if (!m_state)
            {
                throw new InitializeStateException("An state already uninitialized.");
            }

            m_state = false;
        }

        public bool Equals(InitializeState other)
        {
            return m_state == other.m_state;
        }

        public override bool Equals(object obj)
        {
            return obj is InitializeState other && Equals(other);
        }

        public override int GetHashCode()
        {
            return m_state.GetHashCode();
        }

        public static bool operator ==(InitializeState left, InitializeState right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(InitializeState left, InitializeState right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return $"InitializeState: {m_state.ToString()}";
        }
    }
}
