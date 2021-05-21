using System;
using System.Threading.Tasks;

namespace Chronometer
{
    class Program
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            Console.WriteLine("Start or exit?");
            string command = String.Empty;

            while (true)
            {
                command = Console.ReadLine();
                if (command.ToLower() == "start")
                {
                    var task = Task.Run(chronometer.Start);
                    break;
                }
                else if (command.ToLower() == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    continue;
                }
            }

            //while (true)
            //{
            //    command = Console.ReadLine();

            //    if (command.ToLower() == "lap")
            //    {
            //        string lapResult = chronometer.Lap();
            //        Console.WriteLine(lapResult);
            //    }
            //}

            while (true)
            {
                Console.WriteLine(chronometer.Lap());
            }
        }
    }
}
