using NUnit.Framework;

namespace UGF.Initialize.Runtime.Tests
{
    public class TestInitializeBase
    {
        private class Target : InitializeBase
        {
            public new bool ValidateState(bool expected, bool throws = true)
            {
                return base.ValidateState(expected, throws);
            }
        }

        [Test]
        public void Initialize()
        {
            var target = new Target();

            Assert.False(target.IsInitialized);
            Assert.DoesNotThrow(() => target.Initialize());
            Assert.True(target.IsInitialized);
        }

        [Test]
        public void InitializeThrow()
        {
            var target = new Target();

            target.Initialize();

            Assert.True(target.IsInitialized);
            Assert.Throws<InitializeStateException>(() => target.Initialize());
        }

        [Test]
        public void Uninitialize()
        {
            var target = new Target();

            target.Initialize();

            Assert.True(target.IsInitialized);
            Assert.DoesNotThrow(() => target.Uninitialize());
            Assert.False(target.IsInitialized);
        }

        [Test]
        public void UninitializeThrow()
        {
            var target = new Target();

            Assert.False(target.IsInitialized);
            Assert.Throws<InitializeStateException>(() => target.Uninitialize());
        }

        [Test]
        public void ValidateState()
        {
            var target = new Target();

            Assert.True(target.ValidateState(false, false));
            Assert.False(target.ValidateState(true, false));
            Assert.DoesNotThrow(() => target.ValidateState(true, false));
            Assert.Throws<InitializeStateException>(() => target.ValidateState(true));

            target.Initialize();

            Assert.False(target.ValidateState(false, false));
            Assert.True(target.ValidateState(true, false));
        }
    }
}
