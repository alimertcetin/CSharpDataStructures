using System;
using System.Collections.Generic;
using System.Text;
using XIV.DataStructures;

namespace CSharpDataStructures.DataStructureUsages
{
    public class CustomQueueUsage : DataStructureUsage
    {
        public override void Main()
        {
            base.Main();

            CustomQueue<int> cq = new CustomQueue<int>();
            for (int i = 1; i < 101; i++)
            {
                cq.Enqueue(i);
            }

            LogList(cq);
            Console.WriteLine("-----Dequeue");
            for (int i = 1; i < 69; i++)
            {
                Console.WriteLine(cq.Dequeue());
            }
            Console.WriteLine("-----Dequeue");

            Console.WriteLine();

            Console.WriteLine("-----Enqueue");
            for (int i = 1; i < 33; i++)
            {
                cq.Enqueue(i);
            }
            LogList(cq);
            Console.WriteLine("-----Enqueue");
        }
    }
}
