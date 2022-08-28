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

        public static void LogList<T>(IEnumerable<T> list, bool writeItemCount = false)
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

            if (writeItemCount)
            {
                Console.WriteLine("Count : " + count);
            }
        }

        public static void Write(string value, bool writeLine = true)
        {
            if (writeLine)
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.Write(value);
            }
        }
    }
}
