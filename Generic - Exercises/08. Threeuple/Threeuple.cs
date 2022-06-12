using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Exercise
{
    public class Threeuple<T1,T2,T3>
    {
        public Threeuple(T1 first , T2 second , T3 third)
        {
            First = first;
            Second = second;
            Third = third;
        }
        public T1 First { get; set; }
        public T2 Second { get; set; }
        public T3 Third { get; set; }
        public override string ToString()
        {
            return $"{First} -> {Second} -> {Third}";
        }
    }
}
