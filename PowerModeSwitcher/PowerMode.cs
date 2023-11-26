// https://github.com/AaronKelley/PowerMode/blob/main/SetPowerMode.cs
using System.Runtime.InteropServices;

namespace PowerModeSwitcher;

public static class PowerMode
{
    public static readonly Guid BestPowerEfficiency = new("961cc777-2547-4f9d-8174-7d86181b8a7a");
    public static readonly Guid Balanced = new("00000000-0000-0000-0000-000000000000");
    public static readonly Guid BestPerformance = new("ded574b5-45a0-4f42-8737-46345c09c238");
    
    public static bool TrySetPowerMode(Guid id)
    {
        if (GetPowerMode() == id) return false;
        return PowerSetActiveOverlayScheme(id) == 0;
    }

    public static Guid GetPowerMode()
    {
        var error = PowerGetEffectiveOverlayScheme(out var id);
        if (error != 0)
            throw new Exception($"PowerGetEffectiveOverlayScheme failed with error: {error}");
        return id;
    }

    /// <summary>
    /// Retrieves the active overlay power scheme and returns a GUID that identifies the scheme.
    /// </summary>
    /// <param name="EffectiveOverlayPolicyGuid">A pointer to a GUID structure.</param>
    /// <returns>Returns zero if the call was successful, and a nonzero value if the call failed.</returns>
    [DllImport("powrprof.dll", EntryPoint = "PowerGetEffectiveOverlayScheme")]
    private static extern uint PowerGetEffectiveOverlayScheme(out Guid EffectiveOverlayPolicyGuid);

    /// <summary>
    /// Sets the active power overlay power scheme.
    /// </summary>
    /// <param name="OverlaySchemeGuid">The identifier of the overlay power scheme.</param>
    /// <returns>Returns zero if the call was successful, and a nonzero value if the call failed.</returns>
    [DllImportAttribute("powrprof.dll", EntryPoint = "PowerSetActiveOverlayScheme")]
    private static extern uint PowerSetActiveOverlayScheme(Guid OverlaySchemeGuid);
}