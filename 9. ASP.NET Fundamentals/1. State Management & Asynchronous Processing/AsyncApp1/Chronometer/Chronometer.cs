using System.Diagnostics;

namespace Chronometer
{
    internal class Chronometer : IChronometer
    {
        private Stopwatch timer;
        private List<string> laps;

        public Chronometer()
        {
            timer = Stopwatch.StartNew();
            laps = new List<string>();
        }

        public string GetTime => $"{timer.Elapsed.Minutes:d2}:{timer.Elapsed.Seconds:d2}.{timer.ElapsedMilliseconds:d5}";

        public string Lap()
        {
            string current = GetTime;
            laps.Add(current);
            return current;
        }

        public List<string> Laps()
        {
            return laps;
        }

        public void Reset()
        {
            timer.Reset();
            laps.Clear();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}
