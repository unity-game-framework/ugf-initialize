using NUnit.Framework;

namespace UGF.Initialize.Runtime.Tests
{
    public class TestInitializeState
    {
        [Test]
        public void Initialize()
        {
            var state = new InitializeState();

            Assert.False(state.IsInitialized);
            Assert.DoesNotThrow(() => state.Initialize());
            Assert.True(state.IsInitialized);
            Assert.Throws<InitializeStateException>(() => state.Initialize());
        }

        [Test]
        public void Uninitialize()
        {
            var state = new InitializeState();

            state.Initialize();

            Assert.True(state.IsInitialized);
            Assert.DoesNotThrow(() => state.Uninitialize());
            Assert.False(state.IsInitialized);
            Assert.Throws<InitializeStateException>(() => state.Uninitialize());
        }
    }
}
