using System.Collections.Generic;
using XIV.DataStructures;

namespace CSharpDataStructures.DataStructureUsages
{
    public class CustomDictionaryUsage : DataStructureUsage
    {
        public override void Main()
        {
            base.Main();

            // ------------- System.Collections.Generic.Dictionary
            var dictionary = new Dictionary<int, string>(8);
            dictionary.Add(1, "NULL");
            dictionary.Remove(1);
            Dictionary<int, string>.ValueCollection values = dictionary.Values;
            Dictionary<int, string>.KeyCollection keys = dictionary.Keys;
            bool isFound = dictionary.TryGetValue(1, out var val);
            dictionary.Clear();
            bool isKeyExists = dictionary.ContainsKey(1);
            bool isValueExists = dictionary.ContainsValue("NULL");
            bool isAdded = dictionary.TryAdd(1, "NULL");
            int keyCount = dictionary.Count;
            // -------------

            // ------------- XIV.DataStructures.CustomDictionary
            var customDictionary = new CustomDictionary<int, string>(8);
            customDictionary.Add(1, "NULL");
            Write("Key 1 added with NULL value");
            LogList(customDictionary);

            customDictionary.Remove(1);
            Write("Key 1 removed");
            LogList(customDictionary);

            //var customValues = customDictionary.Values; // Not implemented yet
            //var customKeys = dictionary.Keys; // Not implemented yet

            bool customFound = customDictionary.TryGetValue(1, out var customVal);
            if (customFound) Write("1 found, Value is : " + customVal);
            else Write("Couldnt find 1");

            customDictionary.Clear();
            Write("Dictionary cleared");
            LogList(customDictionary);

            bool customIsKeyExists = customDictionary.ContainsKey(1);
            Write("Is key 1 exists : " + customIsKeyExists);

            bool customIsValueExists = customDictionary.ContainsValue("NULL");
            Write("Is value NULL exists : " + customIsValueExists);

            //bool customIsAdded = customDictionary.TryAdd(1, "NULL"); // Not implemented
            int customKeyCount = customDictionary.Count;
            Write("Key Count : " + customKeyCount);

            for (int i = 0; i < 100; i++)
            {
                customDictionary.Add(i, "NULL-" + i);
            }

            customDictionary[1] = "NULL";
            LogList(customDictionary);
        }
    }
}
