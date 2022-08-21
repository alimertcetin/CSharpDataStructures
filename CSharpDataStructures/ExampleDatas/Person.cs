using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CSharpDataStructures
{
    public class PersonAgeComparer : IComparer<Person>
    {
        bool ascending;
        public PersonAgeComparer(bool ascending = true)
        {
            this.ascending = ascending;
        }

        public int Compare(Person x, Person y)
        {
            return ascending ? (int)(x.age - y.age) : (int)(y.age - x.age);
            //return (int)(x.age - y.age);
        }
    }
    public class PersonNameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.name.CompareTo(y.name);
        }
    }

    public class Person : IComparable<Person>
    {
        public string name;
        public uint age;

        public Person() { }

        public Person(string name, uint age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo([AllowNull] Person other)
        {
            if (other == null) return 1;

            return this.age.CompareTo(other.age);
        }

        public override string ToString()
        {
            return $"{name} - {age}";
        }
    }
}
