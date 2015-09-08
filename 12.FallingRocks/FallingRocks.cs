using System;
using System.Threading;

class FallingRocks
{
    static string[] rockScreen = new string[Console.WindowHeight - 1];
    static ConsoleColor[] colors = { ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.White };
    static Random random = new Random(DateTime.Now.Millisecond);
    static int dwarfPosition = Console.WindowWidth / 2;
    static int score = 0;

    static void Main()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
        InitializeArray();
        Game();
        GameOver();
    }
    

    static bool CheckColision()
    {
        string check = rockScreen[2].Substring(dwarfPosition - 1, 3);
        if (check != new string(' ', 3))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    static void DwarfPrint()
    {
        rockScreen[1] = rockScreen[1].Remove(dwarfPosition - 1, 3);
        rockScreen[1] = rockScreen[1].Insert(dwarfPosition, "(O)");
    }

    static void MoveDwarf()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keypress = Console.ReadKey();
            if (keypress.Key == ConsoleKey.LeftArrow && dwarfPosition > 0)
            {
                dwarfPosition -= 1;
            }
            if (keypress.Key == ConsoleKey.RightArrow && dwarfPosition < Console.WindowWidth)
            {
                dwarfPosition += 1;
            }
        }
    }

    static void PrintScreen()
    {
        Console.Clear();
        for (int i = Console.WindowHeight-2; i > 0; i--)
        {
            Console.Write(rockScreen[i]);
        }
    }

    static void InitializeArray()
    {
        for (int i = 0; i < rockScreen.Length; i++)
        {
            rockScreen[i] = new string(' ', Console.WindowWidth);
        }
    }

    static void Game()
    {
        while (CheckColision() == true)
        {
            RocksScreen(RocksLine());
            MoveDwarf();
            DwarfPrint();
            PrintScreen();
            score += 100;
            Thread.Sleep(150);
        }
    }

    static void RocksScreen(string rockLine)
    {
        for (int i = 1; i < rockScreen.Length; i++)
        {
            rockScreen[i -1] = rockScreen[i];
        }
        rockScreen[rockScreen.Length - 1] = rockLine;
    }

    static string RocksLine()
    {
        string rocks = "^@*&+%$#!.;";
        int numberOfRocks = 0;
        numberOfRocks = random.Next(1, 5);
        char[] line = new char[Console.WindowWidth];

        for (int i = 0; i < line.Length; i++)
        {
            line.SetValue(' ', i);
        }

        for (int i = 0; i < numberOfRocks; i++)
        {
            int rockSymbol = random.Next(0, rocks.Length);
            line.SetValue(rocks[rockSymbol], random.Next(1, Console.WindowWidth));
        }
        return new string(line);
    }

    static void GameOver()
    {
        Console.Clear();
        Console.WriteLine("GAME OVER - Your score is : {0}", score);
    }
}

