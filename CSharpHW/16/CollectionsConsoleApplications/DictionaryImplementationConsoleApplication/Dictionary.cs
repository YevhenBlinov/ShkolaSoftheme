using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryImplementationConsoleApplication
{
    public class Dictionary<TKey, TValue>
    {
        private readonly List<KeyValuePair<TKey, TValue>> _itemsList;

        public int Count 
        {
            get { return _itemsList.Count; }
        }

        public Dictionary()
        {
            _itemsList = new List<KeyValuePair<TKey, TValue>>();
        }

        public void Add(TKey key, TValue value)
        {
            if (!HasTheKeyAlready(key))
            {
                var keyValuePair = new KeyValuePair<TKey, TValue>(key, value);
                _itemsList.Add(keyValuePair);
            }
            else
            {
                Console.WriteLine("It's impossible to add a new item, because the dictionary has an item with the same key.");
                Console.WriteLine();
            }
        }

        public void Remove(TKey key)
        {
            if (Count == 0)
            {
                Console.WriteLine("It's impossible to delete the item, because the dictionary hasn't any item.");
                Console.WriteLine();
                return;
            }

            if (HasTheKeyAlready(key))
            {
                var itemToRemove = _itemsList.Single(item => item.Key.Equals(key));
                _itemsList.Remove(itemToRemove);                
            }
            else
            {
                Console.WriteLine("It's impossible to delete the item, because the dictionary hasn't an item with the same key.");
                Console.WriteLine();
            }
        }

        private bool HasTheKeyAlready(TKey key)
        {
            return _itemsList.Any(item => item.Key.Equals(key));
        }

        public void Display()
        {
            Console.WriteLine("The dictionary has {0} items.", Count);

            foreach (var item in _itemsList)
            {
                Console.WriteLine("Key {0} : Value {1}", item.Key, item.Value);
            }

            Console.WriteLine();
        }
    }
}
