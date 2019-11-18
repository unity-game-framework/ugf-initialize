using NUnit.Framework;

namespace UGF.Initialize.Runtime.Tests
{
    public class TestInitializeState
    {
        [Test]
        public void Initialize()
        {
            var state = new InitializeState();

            Assert.False(state);
            Assert.True(state.ValidateState(false));
            Assert.DoesNotThrow(() => state = state.Initialize());
            Assert.True(state);
            Assert.True(state.ValidateState(true));
            Assert.Throws<InitializeStateException>(() => state.Initialize());
        }

        [Test]
        public void Uninitialize()
        {
            var state = new InitializeState();

            state = state.Initialize();

            Assert.True(state);
            Assert.True(state.ValidateState(true));
            Assert.DoesNotThrow(() => state = state.Uninitialize());
            Assert.False(state);
            Assert.True(state.ValidateState(false));
            Assert.Throws<InitializeStateException>(() => state.Uninitialize());
        }
    }
}
