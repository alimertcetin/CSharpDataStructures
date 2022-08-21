using XIV.DataStructures;

namespace CSharpDataStructures.DataStructureUsages
{
    public class CustomLinkedListUsage : DataStructureUsage
    {
        public override void Main()
        {
            base.Main();

            CustomLinkedList<string> customLinkedList = new CustomLinkedList<string>();
            for (int i = 0; i < 10; i++)
            {
                customLinkedList.AddLast(i.ToString());
            }
            customLinkedList.AddFirst("Test");
            customLinkedList.AddLast("Test2");
            Node<string> five = customLinkedList.Find("5");
            customLinkedList.AddBefore(five, "Test3");
            customLinkedList.AddAfter(five, "Test4");

            LogList(customLinkedList);
        }
    }
}
