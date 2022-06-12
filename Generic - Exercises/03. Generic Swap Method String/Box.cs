using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Exercise
{
    public class Box<T>
    {
        public T Element { get; }
        public Box(T element)
        {
            Element = element;
        }

        public Box(List<T> elements)
        {
            Elements = elements;
        }
        public void Swap(List<T> elements,int firstIndex , int secondIndex)
        {
            T firstElement = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = firstElement;
        }
        public List<T> Elements { get;}
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Elements)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
