using System;
using System.Threading;

class Program
{
    static Timer timer;
    static bool isRunning = false;
    static TimeSpan currentTime = TimeSpan.Zero;
    static int timerLine = 4;

    static void Main(string[] args)
    {
        ConsoleKeyInfo keyInfo;
        DisplayMenu();

        timer = new Timer(TimerCallback, null, Timeout.Infinite, 1000);

        do
        {
            keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.S:
                    StartTimer();
                    break;

                case ConsoleKey.P:
                    PauseTimer();
                    break;

                case ConsoleKey.R:
                    ResetTimer();
                    break;

                case ConsoleKey.Q:
                    QuitProgram();
                    break;
            }
        } while (keyInfo.Key != ConsoleKey.Q);
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Press 'S' to start the timer");
        Console.WriteLine("Press 'P' to pause the timer");
        Console.WriteLine("Press 'R' to reset the timer");
        Console.WriteLine("Press 'Q' to quit");
        DisplayTime();
    }

    static void DisplayTime()
    {
        Console.SetCursorPosition(0, timerLine);
        Console.WriteLine($"Timer: {currentTime.ToString(@"hh\:mm\:ss")}       "); // extra spaces to overwrite previous output
    }

    static void TimerCallback(Object o)
    {
        if (isRunning)
        {
            currentTime = currentTime.Add(TimeSpan.FromSeconds(1));
        }
        DisplayTime();
    }

    static void StartTimer()
    {
        if (!isRunning)
        {
            isRunning = true;
            timer.Change(0, 1000);
        }
    }

    static void PauseTimer()
    {
        if (isRunning)
        {
            isRunning = false;
        }
    }

    static void ResetTimer()
    {
        isRunning = false;
        currentTime = TimeSpan.Zero;
        DisplayTime();
    }

    static void QuitProgram()
    {
        timer.Dispose();
        Console.Clear();
        Console.WriteLine("Goodbye!");
        Thread.Sleep(2000);
    }
}
