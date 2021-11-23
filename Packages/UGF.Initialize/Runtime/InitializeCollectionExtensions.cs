using System;

namespace UGF.Initialize.Runtime
{
    public static class InitializeCollectionExtensions
    {
        public static T Create<T>(this IInitializeCollection collection, T element) where T : class, IInitialize
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            collection.Add(element);

            return element;
        }

        public static T Get<TArguments, T>(this IInitializeCollection collection, TArguments arguments, InitializeCollectionPredicate<TArguments, T> predicate) where T : class, IInitialize
        {
            return TryGet(collection, arguments, predicate, out T value) ? value : throw new ArgumentException($"Value not found by the specified arguments: '{arguments}'.");
        }

        public static bool TryGet<TArguments, T>(this IInitializeCollection collection, TArguments arguments, InitializeCollectionPredicate<TArguments, T> predicate, out T value) where T : class, IInitialize
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            for (int i = 0; i < collection.Count; i++)
            {
                value = collection[i] as T;

                if (predicate(arguments, value))
                {
                    return true;
                }
            }

            value = default;
            return false;
        }
    }
}
