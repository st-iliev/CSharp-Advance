using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }
        public List<Person> People { get; set; }
        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOlderstMember()
        {
            Person oldestPerson = People.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestPerson;
        }
    }
}
