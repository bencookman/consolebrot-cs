using System;

public static class UIConsole
{
    /// <summary>
    /// Waits for the user to press a given key
    /// </summary>
    /// <param name="givenKey"></param>
    public static void WaitForKey(ConsoleKey givenKey)
    {
        bool boolPressed;
        do {
            ConsoleKey pressedKey = Console.ReadKey().Key;
            boolPressed = pressedKey.Equals(givenKey);

            if (!boolPressed) {
                Clear.ClearLine();
            }
        } while (!boolPressed);
    }

    public static class Clear
    {
        /// <summary>
        /// Clears this line
        /// </summary>
        public static void ClearLine()
        {
            Console.CursorLeft = 0;
            Console.Write(new string(' ', Console.BufferWidth));
            Console.CursorTop--;
        }

        /// <summary>
        /// Clears the last <number> lines
        /// </summary>
        /// <param name="number"></param>
        public static void ClearLines(int lineCount)
        {
            lineCount = Console.CursorTop < lineCount ? Console.CursorTop : lineCount;

            for (int i = 0; i < lineCount; i++) {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }

        /// <summary>
        /// Clears all lines of the console screen
        /// </summary>
        public static void ClearLines()
        {
            ClearLine();
            int lineTotal = Console.CursorTop;
            ClearLines(lineTotal);
        }
    }
}