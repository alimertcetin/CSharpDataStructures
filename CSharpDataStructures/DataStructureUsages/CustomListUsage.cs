using System;
using XIV.DataStructures;

namespace CSharpDataStructures.DataStructureUsages
{
    public class CustomListUsage : DataStructureUsage
    {
        public override void Main()
        {
            base.Main();

            Random rnd = new System.Random(100);

            string[] nameArr = new string[]
            {
                "Uğur", "Deniz", "Hakan", "Oğuzhan", "Ömer", "Ali",
                "Yağmur", "Damla", "Merve", "Selin", "Selma", "Aslı"
            };

            CustomList<Person> customList = new CustomList<Person>();

            for (int i = 0; i < 100; i++)
            {
                string rndName = nameArr[rnd.Next(0, nameArr.Length)];
                uint rndAge = (uint)rnd.Next(0, 91);
                var person = new Person(rndName, rndAge);
                customList.Add(person);
            }

            // Sort using delegate System.Comparsion<T>
            customList.Sort((Person left, Person right) => (int)(left.age - right.age));
            // Sort using custom class that implements the IComparer<T> interface
            //customList.Sort(new PersonAgeComparer());
            LogList(customList);
        }
    }
}
