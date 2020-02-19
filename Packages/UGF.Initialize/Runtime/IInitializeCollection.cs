using System;
using System.Collections.Generic;

namespace UGF.Initialize.Runtime
{
    public interface IInitializeCollection : IInitialize, IReadOnlyList<IInitialize>
    {
        bool Contains(IInitialize item);
        void Add(IInitialize item);
        bool Remove(IInitialize item);
        void Clear();
        T Get<T>();
        IInitialize Get(Type type);
        bool TryGet<T>(out T item);
        bool TryGet(Type type, out IInitialize item);
    }
}
