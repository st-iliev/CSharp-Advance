using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Exercise
{
    public class Tupe<T1,T2>
    {
        public Tupe(T1 first ,T2 second)
        {
            First = first;
            Second = second;
        }
        public T1 First { get; set; }
        public T2 Second { get; set; }
        public override string ToString()
        {
            return $"{First} -> {Second}";
        }
    }
}
