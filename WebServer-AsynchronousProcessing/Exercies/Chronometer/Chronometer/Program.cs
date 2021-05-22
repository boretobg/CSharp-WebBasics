using System;

namespace Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            Console.WriteLine("Start or Exit?");
            string command = String.Empty;

            while (true)
            {
                command = Console.ReadLine();
                if (command.ToLower() == "start")
                {
                    // var task = Task.Run(chronometer.Start);
                    chronometer.Start();
                    break;
                }
                else if (command.ToLower() == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid command...");
                    continue;
                }
            }

            while (true)
            {
                command = Console.ReadLine();

                if (command.ToLower() == "lap")
                {
                    string lapResult = chronometer.Lap();
                    Console.WriteLine(lapResult);
                }
                else if (command.ToLower() == "laps")
                {
                    if (chronometer.Laps.Count == 0)
                    {
                        Console.WriteLine($"  - Laps: no laps");
                    }

                    int count = 0;
                    foreach (var lap in chronometer.Laps)
                    {
                        Console.WriteLine($"  - {count}. {lap}");
                        count++;
                    }
                }
                else if (command.ToLower() == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
                else if (command.ToLower() == "reset")
                {
                    chronometer.Reset();
                    chronometer.Laps.Clear();
                }
                else if (command.ToLower() == "start")
                {
                    chronometer.Start();
                }
                else if (command.ToLower() == "stop")
                {
                    chronometer.Stop();
                }
                else if (command.ToLower() == "exit")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid command...");
                    continue;
                }
            }
        }
    }
}
