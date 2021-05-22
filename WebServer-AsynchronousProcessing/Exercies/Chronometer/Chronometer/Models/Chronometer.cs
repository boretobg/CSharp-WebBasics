using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch = new Stopwatch();
        private List<string> laps;

        public Chronometer()
        {
            laps = new List<string>();
        }

        public string GetTime 
            => string.Format("{0:mm\\:ss\\:ffff}", stopwatch.Elapsed);

        public List<string> Laps 
            => laps;

        public string Lap()
        {
            var currentLap = GetTime;

            laps.Add(currentLap);

            return currentLap;
        }

        public void Reset() 
            => stopwatch.Reset();

        public void Start() 
            => stopwatch.Start();

        public void Stop() 
            => stopwatch.Stop();
    }
}
