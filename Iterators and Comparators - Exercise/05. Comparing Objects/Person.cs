using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public int Age { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            int result = 0;
            if (this.Name.CompareTo(other.Name)!=0)
            {
                result = this.Name.CompareTo(other.Name);
            }
            else if (this.Age.CompareTo(other.Age) != 0)
            {
                result = this.Age.CompareTo(other.Age);
            }
            else if (this.Town.CompareTo(other.Town) != 0)
            {
                result = this.Town.CompareTo(other.Town);
            }
            return result;
        }
    }
}
