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
            Assert.True(state.ValidateState(false));
            Assert.AreEqual("State", state.Name);
            Assert.DoesNotThrow(() => state.Initialize());
            Assert.True(state.IsInitialized);
            Assert.True(state.ValidateState(true));
            Assert.Throws<InitializeStateException>(() => state.Initialize());
        }

        [Test]
        public void Uninitialize()
        {
            var state = new InitializeState("Test state name");

            Assert.AreEqual("Test state name", state.Name);

            state.Initialize();

            Assert.True(state.IsInitialized);
            Assert.True(state.ValidateState(true));
            Assert.DoesNotThrow(() => state.Uninitialize());
            Assert.False(state.IsInitialized);
            Assert.True(state.ValidateState(false));
            Assert.Throws<InitializeStateException>(() => state.Uninitialize());
        }
    }
}
