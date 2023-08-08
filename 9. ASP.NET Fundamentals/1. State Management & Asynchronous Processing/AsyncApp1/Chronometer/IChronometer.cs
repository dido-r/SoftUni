namespace Chronometer
{
    internal interface IChronometer
    {
        string GetTime { get; }

        List<string> Laps();

        void Start();

        void Stop();

        string Lap();

        void Reset();
    }
}
