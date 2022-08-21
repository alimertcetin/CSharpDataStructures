using System;
using System.Collections.Generic;
using XIV.DataStructures;
using XIV.SortingAlgorithms;

namespace CSharpDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomQueue<int> cq = new CustomQueue<int>();
            //for (int i = 1; i < 101; i++)
            //{
            //    cq.Enqueue(i);
            //}

            //LogList(cq);
            //Console.WriteLine("-----Dequeue");
            //for (int i = 1; i < 69; i++)
            //{
            //    Console.WriteLine(cq.Dequeue());
            //}
            //Console.WriteLine("-----Dequeue");

            //Console.WriteLine();

            //Console.WriteLine("-----Enqueue");
            //for (int i = 1; i < 33; i++)
            //{
            //    cq.Enqueue(i);
            //}
            //LogList(cq);
            //Console.WriteLine("-----Enqueue");


            //CustomStack<string> cs = new CustomStack<string>();
            //for (int i = 10; i < 101; i++)
            //{
            //    cs.Push("Test" + i);
            //}
            //LogList(cs);

            //for (int i = 10; i < 101; i++)
            //{
            //    cs.Pop();
            //}

            //Console.WriteLine(cs.Peek());


            //CustomLinkedList<string> customLinkedList = new CustomLinkedList<string>();
            //for (int i = 0; i < 10; i++)
            //{
            //    customLinkedList.AddLast(i.ToString());
            //}
            //customLinkedList.AddFirst("Test");
            //customLinkedList.AddLast("Test2");
            //Node<string> five = customLinkedList.Find("5");
            //customLinkedList.AddBefore(five, "Test3");
            //customLinkedList.AddAfter(five, "Test4");

            //LogList(customLinkedList);

            //CustomHashSet<string> customHashSet = new CustomHashSet<string>(1);
            //customHashSet.Add("Test");
            //customHashSet.Add("Test2");
            //customHashSet.Add("Test3");
            //customHashSet.Add("Test4");

            //customHashSet.Add("Test");
            //customHashSet.Add("1");
            //customHashSet.Add("2");
            //customHashSet.Add("3");
            //customHashSet.Add("4");

            //LogList(customHashSet);

            //if (customHashSet.Contains("Test"))
            //{
            //    Console.WriteLine("Test exists");
            //}

            Random rnd = new System.Random(100);

            string[] nameArr = new string[]
            {
                "Uğur", "Deniz", "Hakan", "Oğuzhan", "Ömer", "Ali",
                "Yağmur", "Damla", "Merve", "Selin", "Selma", "Aslı"
            };

            //CustomList<Person> customList = new CustomList<Person>();

            //for (int i = 0; i < 100; i++)
            //{
            //    string rndName = nameArr[rnd.Next(0, nameArr.Length)];
            //    uint rndAge = (uint)rnd.Next(0, 91);
            //    var person = new Person(rndName, rndAge);
            //    customList.Add(person);
            //}

            //// Sort using delegate System.Comparsion<T>
            ////customList.Sort((Person left, Person right) => (int)(left.age - right.age));
            //// Sort using custom class that implements the IComparer<T> interface
            //customList.Sort(new PersonAgeComparer(false));
            //LogList(customList);

            const int arrLength = 5;
            Person[] arr = new Person[arrLength];

            for (int i = 0; i < arrLength; i++)
            {
                string rndName = nameArr[rnd.Next(0, nameArr.Length)];
                uint rndAge = (uint)rnd.Next(0, 91);
                var person = new Person(rndName, rndAge);
                arr[i] = person;
            }
            //for (int i = 0; i < arrLength; i++)
            //{
            //    var swapIdxFirst = rnd.Next(0, arrLength);
            //    var swapIdxSecond = rnd.Next(0, arrLength);
            //    (arr[swapIdxFirst], arr[swapIdxSecond]) = (arr[swapIdxSecond], arr[swapIdxFirst]);
            //}


            Console.WriteLine("Unsorted");
            LogList(arr);
            Console.WriteLine();
            Console.WriteLine("Heap Sorted");
            //HeapSorting.Sort(arr, arrLength, (Person x, Person y) => (int)(y.age - x.age));
            HeapSorting.Sort(arr, arrLength);

            LogList(arr);

            //var list = new RefIndexerList<int>();
            //for (int i = 0; i <= 100; i++)
            //{
            //    list.Add(i);
            //}



            //LogList(list);
            //Console.WriteLine("Capacity : " + list.Capacity);
            //Console.WriteLine("--------------------------------------------");

            //for (int i = 25; i <= 50; i++)
            //{
            //    list.Insert(i, 1);
            //}
            //LogList(list);
            //Console.WriteLine("Capacity : " + list.Capacity);
            //Console.WriteLine("--------------------------------------------");

            //for (int i = 0; i < 25; i++)
            //{
            //    list.RemoveAt(i);
            //}

            //LogList(list);
            //Console.WriteLine("Capacity : " + list.Capacity);
            //Console.WriteLine("--------------------------------------------");
            Console.ReadKey();
        }

        public static void LogList<T>(IEnumerable<T> list)
        {
            string log = "";
            int count = 0;
            foreach (var item in list)
            {
                log += item.ToString() + Environment.NewLine;
                count++;
            }
            Console.WriteLine(log);
            Console.WriteLine();
            Console.WriteLine("Count : " + count);
        }
    }
}