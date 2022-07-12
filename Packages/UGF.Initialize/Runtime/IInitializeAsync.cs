using System.Threading.Tasks;

namespace UGF.Initialize.Runtime
{
    public interface IInitializeAsync : IInitialize
    {
        bool IsInitializedAsync { get; }

        Task InitializeAsync();
    }
}
