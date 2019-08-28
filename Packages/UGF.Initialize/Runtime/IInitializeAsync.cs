using System.Collections;

namespace UGF.Initialize.Runtime
{
    public interface IInitializeAsync : IInitialize
    {
        IEnumerator InitializeAsync();
    }
}
