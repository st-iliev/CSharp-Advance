﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> collection;
        public Stack(params T[] elemenets)
        {
            this.collection = new List<T>(elemenets);
        }
        public void Push(params T[] elemenets)
        {
            foreach (var item in elemenets)
            {
                collection.Add(item);
            }
        }
        public T Pop()
        {
            if (collection.Count == 0)
            {
                throw new ArgumentException("No elements");
            }
            T lastElement = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count - 1);
            return lastElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
