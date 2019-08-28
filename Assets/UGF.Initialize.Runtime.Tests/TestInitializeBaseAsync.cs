using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace UGF.Initialize.Runtime.Tests
{
    public class TestInitializeBaseAsync
    {
        private class Target : InitializeBaseAsync
        {
            public bool InitializeAsyncState { get; private set; }

            protected override IEnumerator OnInitializeAsync()
            {
                yield return null;

                InitializeAsyncState = true;
            }

            protected override void OnUninitialize()
            {
                base.OnUninitialize();

                InitializeAsyncState = false;
            }
        }

        [UnityTest]
        public IEnumerator InitializeAsync()
        {
            var target = new Target();

            target.Initialize();

            Assert.True(target.IsInitialized);
            Assert.False(target.InitializeAsyncState);

            yield return target.InitializeAsync();

            Assert.True(target.InitializeAsyncState);

            target.Uninitialize();

            Assert.False(target.IsInitialized);
            Assert.False(target.InitializeAsyncState);
        }
    }
}
