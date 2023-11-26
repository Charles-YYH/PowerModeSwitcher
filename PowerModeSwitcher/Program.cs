using System.Drawing;

namespace PowerModeSwitcher;

internal abstract class Program
{
    private const int HistoryPointCount = 120;
    private const int Interval = 1000;
    private static readonly Point[] _points = new Point[HistoryPointCount];

    // Set power mode to best power efficiency if idle for 120s
    private static void Main()
    {
        var tick = 0;
        while (true)
        {
            _points[tick++ % HistoryPointCount] = Mouse.GetCursorPosition();
            Thread.Sleep(Interval);
            var powerMode = CheckActivity() ? PowerMode.Balanced : PowerMode.BestPowerEfficiency;
            PowerMode.TrySetPowerMode(powerMode);
        }
    }

    private static bool CheckActivity()
    {
        if (_points.Any(point => point.Equals(default))) return true;
        var first = _points.First();
        return _points.Any(point => point != first);
    }
}