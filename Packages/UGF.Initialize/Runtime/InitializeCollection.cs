using System;
using System.Collections;
using System.Collections.Generic;

namespace UGF.Initialize.Runtime
{
    public class InitializeCollection<TItem> : InitializeBase, IInitializeCollection, IEnumerable<TItem> where TItem : class, IInitialize
    {
        public int Count { get { return m_collection.Count; } }
        public TItem this[int index] { get { return m_collection[index]; } }
        public bool ReverseUninitializationOrder { get; set; } = true;

        IInitialize IReadOnlyList<IInitialize>.this[int index] { get { return m_collection[index]; } }

        private readonly List<TItem> m_collection = new List<TItem>();

        protected override void OnInitialize()
        {
            base.OnInitialize();

            for (int i = 0; i < m_collection.Count; i++)
            {
                m_collection[i].Initialize();
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            if (ReverseUninitializationOrder)
            {
                for (int i = m_collection.Count - 1; i >= 0; i--)
                {
                    m_collection[i].Uninitialize();
                }
            }
            else
            {
                for (int i = 0; i < m_collection.Count; i++)
                {
                    m_collection[i].Uninitialize();
                }
            }
        }

        public bool Contains(TItem value)
        {
            return m_collection.Contains(value);
        }

        public void Add(TItem value)
        {
            m_collection.Add(value);
        }

        public bool Remove(TItem value)
        {
            return m_collection.Remove(value);
        }

        public void Clear()
        {
            m_collection.Clear();
        }

        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }

        public IInitialize Get(Type type)
        {
            if (!TryGet(type, out IInitialize value))
            {
                throw new ArgumentException($"Value by the specified type not found: '{type}'.");
            }

            return value;
        }

        public bool TryGet<T>(out T item)
        {
            if (TryGet(typeof(T), out IInitialize value))
            {
                item = (T)value;
                return true;
            }

            item = default;
            return false;
        }

        public bool TryGet(Type type, out IInitialize item)
        {
            for (int i = 0; i < m_collection.Count; i++)
            {
                item = m_collection[i];

                if (type.IsInstanceOfType(item))
                {
                    return true;
                }
            }

            item = null;
            return false;
        }

        public List<TItem>.Enumerator GetEnumerator()
        {
            return m_collection.GetEnumerator();
        }

        bool IInitializeCollection.Contains(IInitialize item)
        {
            return Contains((TItem)item);
        }

        void IInitializeCollection.Add(IInitialize item)
        {
            Add((TItem)item);
        }

        bool IInitializeCollection.Remove(IInitialize item)
        {
            return Remove((TItem)item);
        }

        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator()
        {
            return m_collection.GetEnumerator();
        }

        IEnumerator<IInitialize> IEnumerable<IInitialize>.GetEnumerator()
        {
            return m_collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_collection.GetEnumerator();
        }
    }
}
