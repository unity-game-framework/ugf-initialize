using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace UGF.Initialize.Runtime.Tests
{
    [Obsolete]
    public class TestInitializeBaseAsync
    {
        private class Target : InitializeBaseAsync
        {
            protected override IEnumerator OnInitializeAsync()
            {
                yield return null;
            }
        }

        [UnityTest]
        public IEnumerator InitializeAsync()
        {
            var target = new Target();

            target.Initialize();

            Assert.True(target.IsInitialized);
            Assert.False(target.IsAsyncInitialized);
            Assert.False(target.IsAsyncInProgress);

            IEnumerator routine = target.InitializeAsync();

            Assert.False(target.IsAsyncInitialized);
            Assert.True(target.IsAsyncInProgress);

            yield return routine;

            Assert.True(target.IsAsyncInitialized);
            Assert.False(target.IsAsyncInProgress);

            target.Uninitialize();

            Assert.False(target.IsInitialized);
            Assert.False(target.IsAsyncInitialized);
            Assert.False(target.IsAsyncInProgress);
        }
    }
}
