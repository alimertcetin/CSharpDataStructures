using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpDataStructures.DataStructureUsages
{
    public abstract class DataStructureUsage
    {
        static StringBuilder writer = new StringBuilder();
        static StringBuilder listLogger = new StringBuilder();

        public virtual void Main()
        {
            Write("--------- " + this.GetType().Name + " ---------", 2);
        }

        public static void LogList<T>(IEnumerable<T> list, bool writeItemCount = false)
        {
            int itemCount = 0;
            foreach (var item in list)
            {
                listLogger.Append(item.ToString());
                listLogger.AppendLine();
                itemCount++;
            }
            listLogger.AppendLine();
            Console.WriteLine(listLogger);

            if (writeItemCount)
            {
                Console.WriteLine("Count : " + itemCount);
            }

            listLogger.Clear();
        }

        public static void Write(string value, int lineSpace = 1)
        {
            writer.Append(value);
            for (int i = 0; i < lineSpace; i++)
            {
                writer.AppendLine();
            }

            Console.Write(writer);
            writer.Clear();
        }
    }
}
