namespace UGF.Initialize.Runtime
{
    public interface IInitialize
    {
        bool IsInitialized { get; }

        void Initialize();
        void Uninitialize();
    }
}
