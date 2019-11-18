namespace UGF.Initialize.Runtime
{
    /// <summary>
    /// Represents initialize state.
    /// </summary>
    public struct InitializeState
    {
        /// <summary>
        /// Gets the value of the current state.
        /// </summary>
        public bool Value { get; }

        /// <summary>
        /// Creates state with the specified value.
        /// </summary>
        /// <param name="value">The value of the state.</param>
        public InitializeState(bool value)
        {
            Value = value;
        }

        /// <summary>
        /// Changes current state to initialized.
        /// </summary>
        public InitializeState Initialize()
        {
            if (Value)
            {
                throw new InitializeStateException("A state already initialized.");
            }

            return new InitializeState(true);
        }

        /// <summary>
        /// Changes current state to uninitialized.
        /// </summary>
        public InitializeState Uninitialize()
        {
            if (!Value)
            {
                throw new InitializeStateException("A state already uninitialized.");
            }

            return new InitializeState(false);
        }

        /// <summary>
        /// Validates current state.
        /// </summary>
        /// <param name="expected">The expected initialize state.</param>
        /// <param name="throws">The value that determines whether to throw exception on invalid validate result.</param>
        public bool ValidateState(bool expected, bool throws = true)
        {
            return InitializeUtility.ValidateState(expected, Value, null, throws);
        }

        public bool Equals(InitializeState other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is InitializeState other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(InitializeState left, InitializeState right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(InitializeState left, InitializeState right)
        {
            return !left.Equals(right);
        }

        public static implicit operator bool(InitializeState state)
        {
            return state.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
