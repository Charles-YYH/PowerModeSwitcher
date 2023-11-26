namespace PowerModeSwitcher;

internal abstract class Program
{
    private static void Main()
    {
        var id = PowerMode.GetPowerMode();
        Console.Out.WriteLine(id);
    }
}