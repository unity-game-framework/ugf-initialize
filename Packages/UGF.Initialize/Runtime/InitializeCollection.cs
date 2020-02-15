using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UGF.Initialize.Runtime
{
    public class InitializeCollection : InitializeBase, IEnumerable<IInitialize>
    {
        public IReadOnlyList<IInitialize> Collection { get; }
        public bool ReverseUninitializationOrder { get; set; } = true;

        private readonly List<IInitialize> m_collection;

        public InitializeCollection()
        {
            m_collection = new List<IInitialize>();

            Collection = new ReadOnlyCollection<IInitialize>(m_collection);
        }

        public InitializeCollection(IEnumerable<IInitialize> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            m_collection = new List<IInitialize>(collection);
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

        public void Add(IInitialize value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            m_collection.Add(value);
        }

        public bool Remove(IInitialize value)
        {
            return m_collection.Remove(value);
        }

        public List<IInitialize>.Enumerator GetEnumerator()
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
