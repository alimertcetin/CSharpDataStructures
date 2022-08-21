using System;
using XIV.DataStructures;

namespace CSharpDataStructures.DataStructureUsages
{
    public class CustomStackUsage : DataStructureUsage
    {
        public override void Main()
        {
            base.Main();

            CustomStack<string> cs = new CustomStack<string>();
            for (int i = 10; i < 101; i++)
            {
                cs.Push("Test" + i);
            }
            LogList(cs);

            for (int i = 10; i < 101; i++)
            {
                cs.Pop();
            }

            Console.WriteLine(cs.Peek());
        }
    }
}
