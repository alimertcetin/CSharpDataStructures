using CSharpDataStructures.DataStructureUsages;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XIV.Console;
using XIV.Core;

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

            Time.Start();

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

                Thread.Sleep(1000);

                Time.Update();
                Console.WriteLine("Passed Time -----> " + Time.DeltaTime);
            }
            Console.WriteLine("Loop ended");
            Console.ReadKey();
        }
    }
}