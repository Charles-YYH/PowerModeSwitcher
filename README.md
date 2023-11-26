# PowerModeSwitcher

This repo contains some example code snippets to change Power Mode programatically with C#.

## Structure

- `PowerMode.cs`: a static class wraps windows API calls to change power mode
- `Mouse.cs`: a static class wraps windows API calls to get mouse cursor position
- `Program.cs`: a demo shows how to change power mode dynamically while idle

## How it works

This repo takes the code from https://github.com/AaronKelley/PowerMode, it has a detailed explanation on the usage of
undocumented Windows API methods to change the Windows power mode.

## Power Mode

Power mode allows you to optimize your Windows 11 device based on power use and performance.

You can choose between the Best power efficiency, Balanced (default), or Best performance power mode.

- Best power efficiency: Saves power by reducing PC performance and screen brightness.
- Balanced: Offers full performance when you need it and saves power when you don't.
- Best performance: Maximizes screen brightness and might increase PC performance.

The Power Mode setting is saved to the `ActiveOverlayAcPowerScheme` string value (REG_SZ) in the protected registry key:
**HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\User\PowerSchemes**

- Best power efficiency: 961cc777-2547-4f9d-8174-7d86181b8a7a
- Balanced: 00000000-0000-0000-0000-000000000000
- Best performance: ded574b5-45a0-4f42-8737-46345c09c238

Remarks: 
- There also exists `ActiveOverlayDcPowerScheme` to control power mode while powered by battery
- Changing values for `ActiveOverlayAcPowerScheme` directly will not have effect