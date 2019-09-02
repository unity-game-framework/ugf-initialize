using NUnit.Framework;

namespace UGF.Initialize.Runtime.Tests
{
    public class TestInitializeUtility
    {
        private class Target : InitializeBase
        {
        }

        [Test]
        public void ValidateStateDeprecated()
        {
#pragma warning disable 618
            var target = new Target();

            Assert.True(InitializeUtility.ValidateState(target, false, false));
            Assert.False(InitializeUtility.ValidateState(target, true, false));
            Assert.DoesNotThrow(() => InitializeUtility.ValidateState(target, true, false));
            Assert.Throws<InitializeStateException>(() => InitializeUtility.ValidateState(target, true));

            target.Initialize();

            Assert.False(InitializeUtility.ValidateState(target, false, false));
            Assert.True(InitializeUtility.ValidateState(target, true, false));
#pragma warning restore 618
        }

        [Test]
        public void ValidateState()
        {
            var target = new Target();

            Assert.True(InitializeUtility.ValidateState(false, false, null, false));
            Assert.False(InitializeUtility.ValidateState(true, false, null, false));
            Assert.DoesNotThrow(() => InitializeUtility.ValidateState(true, false, null, false));
            Assert.Throws<InitializeStateException>(() => InitializeUtility.ValidateState(true, false));

            target.Initialize();

            Assert.False(InitializeUtility.ValidateState(false, true, null, false));
            Assert.True(InitializeUtility.ValidateState(true, true, null, false));
        }
    }
}
