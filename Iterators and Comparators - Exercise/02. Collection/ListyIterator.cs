using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsandComparatorsExercise
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index;
        public ListyIterator(params T[] elements)
        {
            this.elements = new List<T>(elements);
            index = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool HasNext()
        {
            if (index < elements.Count-1)
            {
                return true;
            }
            return false;
        }
        public bool Move()
        {
            bool canMove = HasNext();
            if (canMove)
            {
                ++index;
            }
            return canMove;
        }
        public void Print()
        {
            if (elements.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
                Console.WriteLine($"{elements[index]}");
        }
        public void PrintAll()
        {
            foreach (var item in elements)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in elements)
            {
                yield return item;
            }
        }
    }
}
