using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UGF.Initialize.Runtime
{
    public class InitializeCollection<TITem> : InitializeBase, IEnumerable<TITem> where TITem : class, IInitialize
    {
        public IReadOnlyList<TITem> Collection { get; }
        public bool ReverseUninitializationOrder { get; set; } = true;

        private readonly List<TITem> m_collection;

        public InitializeCollection()
        {
            m_collection = new List<TITem>();

            Collection = new ReadOnlyCollection<TITem>(m_collection);
        }

        public InitializeCollection(IEnumerable<TITem> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            m_collection = new List<TITem>(collection);
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

        public void Add(TITem value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            m_collection.Add(value);
        }

        public bool Remove(TITem value)
        {
            return m_collection.Remove(value);
        }

        public List<TITem>.Enumerator GetEnumerator()
        {
            return m_collection.GetEnumerator();
        }

        IEnumerator<TITem> IEnumerable<TITem>.GetEnumerator()
        {
            return m_collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_collection.GetEnumerator();
        }
    }
}
