using CSharpDataStructures.DataStructureUsages;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

            Input input = new Input();
            Thread inputThread = new Thread(() =>
            {
                while (true)
                {
                    input.InputUpdate();
                }
            });
            inputThread.IsBackground = true;
            inputThread.Start();

            while (true)
            {
                if (input.GetKeyDown(ConsoleKey.Escape))
                {
                    break;
                }

                foreach (DataStructureUsage structureUsage in structureUsages)
                {
                    structureUsage.Main();
                }

                input.ClearInputData(); //race condition
                Thread.Sleep(500);
            }
            Console.WriteLine("Loop ended");
            Console.ReadKey();
        }
    }
}