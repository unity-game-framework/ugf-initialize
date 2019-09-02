using System;

namespace UGF.Initialize.Runtime
{
    /// <summary>
    /// Represents mutable initialize state.
    /// </summary>
    public struct InitializeState : IInitialize
    {
        public bool IsInitialized { get { return m_state; } }
        public string Name { get { return m_name ?? "State"; } }

        private readonly string m_name;
        private bool m_state;

        public InitializeState(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            m_name = name;
            m_state = false;
        }

        public void Initialize()
        {
            if (m_state)
            {
                throw new InitializeStateException($"A '{Name}' already initialized.");
            }

            m_state = true;
        }

        public void Uninitialize()
        {
            if (!m_state)
            {
                throw new InitializeStateException($"A '{Name}' already uninitialized.");
            }

            m_state = false;
        }

        public bool ValidateState(bool expected, bool throws = true)
        {
            return InitializeUtility.ValidateState(expected, m_state, Name, throws);
        }

        public bool Equals(InitializeState other)
        {
            return m_name == other.m_name && m_state == other.m_state;
        }

        public override bool Equals(object obj)
        {
            return obj is InitializeState other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((m_name != null ? m_name.GetHashCode() : 0) * 397) ^ m_state.GetHashCode();
            }
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
            return $"'{Name}': '{m_state.ToString()}'";
        }
    }
}
