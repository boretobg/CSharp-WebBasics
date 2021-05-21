using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private float milliseconds = 0;
        private int seconds = 0;
        private int minutes = 0;
        private long current = 0;

        public string GetTime => throw new NotImplementedException();

        public List<string> Laps => throw new NotImplementedException();

        public string Lap()
        {
            return $"{minutes}:{seconds}:{current}";
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            var stopwatch = new Stopwatch();

            while (true)
            {
                while (seconds < 60)
                {
                    while (milliseconds < 1000)
                    {
                        stopwatch.Start();
                        milliseconds++;
                        current = stopwatch.ElapsedMilliseconds;
                    }
                    stopwatch.Restart();

                    Thread.Sleep(1000);
                    seconds++;
                    milliseconds = 0;
                }
                
                minutes++;
                seconds = 0;
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
