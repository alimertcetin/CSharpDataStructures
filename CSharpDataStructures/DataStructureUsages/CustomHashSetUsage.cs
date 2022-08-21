using System;
using XIV.DataStructures;

namespace CSharpDataStructures.DataStructureUsages
{
    public class CustomHashSetUsage : DataStructureUsage
    {

        public override void Main()
        {
            base.Main();

            CustomHashSet<string> customHashSet = new CustomHashSet<string>(1);
            customHashSet.Add("Test");
            customHashSet.Add("Test2");
            customHashSet.Add("Test3");
            customHashSet.Add("Test4");

            customHashSet.Add("Test");
            customHashSet.Add("1");
            customHashSet.Add("2");
            customHashSet.Add("3");
            customHashSet.Add("4");

            LogList(customHashSet);

            if (customHashSet.Contains("Test"))
            {
                Console.WriteLine("Test exists");
            }
        }
    }
}
