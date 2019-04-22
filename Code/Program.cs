using System;

class Program
{
    const float charAspect = (float)66 / 132;
    static float zoom;
    static int width;
    static int height;

    static double xOffset = 0;
    static double yOffset = 0;

    static void Main()
    {
        Mandlebrot.MaxCount = 100;
        Console.SetWindowSize(Console.LargestWindowWidth - 10, Console.LargestWindowHeight - 10);

        zoom = (float)1 / 45;
        width = Console.WindowWidth;
        height = Console.WindowHeight - 1;

        ConsoleKey keyPressed;

        do {
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {

                    double xMin = -width * zoom * charAspect + xOffset;
                    double xMax = width * zoom * charAspect + xOffset;
                    double yMin = -height * zoom + yOffset;
                    double yMax = height * zoom + yOffset;

                    double a = UsefulMath.Map(0, width - 1, xMin, xMax, x);
                    double b = UsefulMath.Map(0, height - 1, yMin, yMax, y);

                    string charToWrite = Mandlebrot.InSet(Mandlebrot.MandlebrotCalc(a, b)) ? "o" : " ";

                    Console.SetCursorPosition(x, y);
                    Console.Write(charToWrite[0]);
                }
            }
            keyPressed = Console.ReadKey().Key;

            switch (keyPressed) {
                // Change Offsets
                case ConsoleKey.LeftArrow:
                    xOffset -= 0.45f * zoom * 45;
                    break;
                case ConsoleKey.RightArrow:
                    xOffset += 0.45f * zoom * 45;
                    break;
                case ConsoleKey.UpArrow:
                    yOffset -= 0.45f * zoom * 45;
                    break;
                case ConsoleKey.DownArrow:
                    yOffset += 0.45f * zoom * 45;
                    break;

                // Change zooms
                case ConsoleKey.PageUp:
                    zoom /= 2;
                    break;
                case ConsoleKey.PageDown:
                    zoom *= 2;
                    break;
            }

        } while (!keyPressed.Equals(ConsoleKey.Escape));
    }
}