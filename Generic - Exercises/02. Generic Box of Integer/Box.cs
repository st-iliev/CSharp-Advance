using System;
using System.Collections.Generic;
using System.Text;

namespace GenericExercise
{
    public class Box<T>
    {
        public T Element { get; }
        public Box(T element)
        {
            Element = element;
        }
        public override string ToString()
        {
            return $"{typeof(T)}: {Element}";
        }
    }
}
