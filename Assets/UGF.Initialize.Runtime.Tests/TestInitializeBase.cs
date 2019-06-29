using System;
using NUnit.Framework;

namespace UGF.Initialize.Runtime.Tests
{
    public class TestInitializeBase
    {
        private class Target : InitializeBase
        {
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
            Assert.Throws<InvalidOperationException>(() => target.Initialize(), "The object already initialized.");
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
            Assert.Throws<InvalidOperationException>(() => target.Uninitialize(), "The object already uninitialized.");
        }
    }
}
