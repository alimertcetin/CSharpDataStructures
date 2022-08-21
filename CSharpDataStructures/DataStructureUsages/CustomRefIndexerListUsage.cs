using System;
using XIV.DataStructures;

namespace CSharpDataStructures.DataStructureUsages
{
    public class CustomRefIndexerListUsage : DataStructureUsage
    {
        public override void Main()
        {
            base.Main();

            var list = new CustomRefIndexerList<int>();
            for (int i = 0; i <= 100; i++)
            {
                list.Add(i);
            }

            LogList(list);
            Console.WriteLine("Capacity : " + list.Capacity);
            Console.WriteLine("--------------------------------------------");

            for (int i = 25; i <= 50; i++)
            {
                list.Insert(i, 1);
            }
            LogList(list);
            Console.WriteLine("Capacity : " + list.Capacity);
            Console.WriteLine("--------------------------------------------");

            for (int i = 0; i < 25; i++)
            {
                list.RemoveAt(i);
            }

            LogList(list);
            Console.WriteLine("Capacity : " + list.Capacity);
            Console.WriteLine("--------------------------------------------");
        }
    }
}
