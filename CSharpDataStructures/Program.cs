using CSharpDataStructures.DataStructureUsages;
using System;
using System.Collections.Generic;

namespace CSharpDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DataStructureUsage> structureUsages = new List<DataStructureUsage>
            {
                //new CustomHashSetUsage(),
                //new CustomLinkedListUsage(),
                //new CustomListUsage(),
                //new CustomQueueUsage(),
                //new CustomRefIndexerListUsage(),
                //new CustomStackUsage(),
                new CustomDictionaryUsage(),
            };


            foreach (DataStructureUsage structureUsage in structureUsages)
            {
                structureUsage.Main();
            }

            Console.ReadKey();
        }
    }
}