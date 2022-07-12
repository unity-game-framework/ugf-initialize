using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UGF.Initialize.Runtime
{
    public class InitializeCollection<TItem> : InitializeBase, IInitializeCollection, IInitializeAsync where TItem : class, IInitialize
    {
        public int Count { get { return m_collection.Count; } }
        public TItem this[int index] { get { return m_collection[index]; } }
        public bool ReverseUninitializationOrder { get; }
        public bool IsInitializedAsync { get { return m_state; } }

        IInitialize IReadOnlyList<IInitialize>.this[int index] { get { return m_collection[index]; } }

        private InitializeState m_state;
        private readonly List<TItem> m_collection = new List<TItem>();

        public InitializeCollection() : this(true)
        {
        }

        public InitializeCollection(bool reverseUninitializationOrder)
        {
            ReverseUninitializationOrder = reverseUninitializationOrder;
        }

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

            if (m_state)
            {
                m_state = m_state.Uninitialize();
            }

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

        public async Task InitializeAsync()
        {
            if (!IsInitialized) throw new InitializeStateException();

            m_state = m_state.Initialize();

            for (int i = 0; i < m_collection.Count; i++)
            {
                TItem item = m_collection[i];

                if (item is IInitializeAsync initialize)
                {
                    await initialize.InitializeAsync();
                }
            }
        }

        public bool Contains(TItem value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            return m_collection.Contains(value);
        }

        public void Add(TItem value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            m_collection.Add(value);
        }

        public bool Remove(TItem value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

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
            return TryGet(type, out IInitialize value) ? value : throw new ArgumentException($"Value not found by the specified type: '{type}'.");
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
            if (type == null) throw new ArgumentNullException(nameof(type));

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
