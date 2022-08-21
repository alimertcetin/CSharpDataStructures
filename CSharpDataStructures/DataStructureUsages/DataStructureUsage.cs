using System;
using System.Collections.Generic;

namespace CSharpDataStructures.DataStructureUsages
{
    public abstract class DataStructureUsage
    {

        public virtual void Main()
        {
            System.Console.WriteLine("--------- " + this.GetType().Name + " ---------");
        }

        public void LogList<T>(IEnumerable<T> list)
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
