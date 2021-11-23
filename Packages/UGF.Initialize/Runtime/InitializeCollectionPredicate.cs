namespace UGF.Initialize.Runtime
{
    public delegate bool InitializeCollectionPredicate<in TArguments, in TValue>(TArguments arguments, TValue value) where TValue : class, IInitialize;
}
