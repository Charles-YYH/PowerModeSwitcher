// https://stackoverflow.com/a/5577528/8877198
using System.Drawing;
using System.Runtime.InteropServices;

namespace PowerModeSwitcher;

/// <summary>
/// Struct representing a point.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct POINT
{
    public int X;
    public int Y;

    public static implicit operator Point(POINT point)
    {
        return new Point(point.X, point.Y);
    }
}

public static class Mouse
{
    /// <summary>
    /// Retrieves the cursor's position, in screen coordinates.
    /// </summary>
    /// <see>See MSDN documentation for further information.</see>
    [DllImport("user32.dll")]
    private static extern bool GetCursorPos(out POINT lpPoint);

    public static Point GetCursorPosition()
    {
        var success = GetCursorPos(out var lpPoint);
        if (!success)
            throw new Exception("GetCursorPos failed");
        return lpPoint;
    }
}