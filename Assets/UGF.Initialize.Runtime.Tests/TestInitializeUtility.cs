using NUnit.Framework;

namespace UGF.Initialize.Runtime.Tests
{
    public class TestInitializeUtility
    {
        private class Target : InitializeBase
        {
        }

        [Test]
        public void ValidateState()
        {
            var target = new Target();

            Assert.True(InitializeUtility.ValidateState(target, false, false));
            Assert.False(InitializeUtility.ValidateState(target, true, false));
            Assert.DoesNotThrow(() => InitializeUtility.ValidateState(target, true, false));
            Assert.Throws<InitializeStateException>(() => InitializeUtility.ValidateState(target, true));

            target.Initialize();

            Assert.False(InitializeUtility.ValidateState(target, false, false));
            Assert.True(InitializeUtility.ValidateState(target, true, false));
        }
    }
}
