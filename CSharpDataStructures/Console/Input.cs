namespace XIV.Console
{
    using System;
    using XIV.DataStructures;
    using Console = System.Console;

    public class Input
    {
        CustomDictionary<ConsoleKey, bool> keyMap;

        public Input()
        {
            Array enumMembers = Enum.GetValues(typeof(ConsoleKey));
            int length = enumMembers.Length;
            keyMap = new CustomDictionary<ConsoleKey, bool>(length);

            for (int i = 0; i < length; i++)
            {
                var consoleKey = (ConsoleKey)enumMembers.GetValue(i);
                keyMap.Add(consoleKey, false);
            }
        }

        /// <summary>
        /// True if any key press happens
        /// </summary>
        /// <returns>Returns true when supported key press happens, otherwise false</returns>
        public bool InputUpdate()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                if (keyMap.ContainsKey(key))
                {
                    return keyMap[key] = true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Is key pressed
        /// </summary>
        /// <param name="consoleKey">Key to check</param>
        /// <returns>True if <paramref name="consoleKey"/> is pressed</returns>
        public bool GetKeyDown(ConsoleKey consoleKey)
        {
            return keyMap.TryGetValue(consoleKey, out var isPressed) ? isPressed : false;
        }

        public void ClearInputData()
        {
            // Our custom dictionary doesnt detect version changes
            // In regular dictionary this will throw an exception that says collection has been modified
            foreach (var key in keyMap.Keys)
            {
                keyMap[key] = false;
            }
        }

    }
}
