using static DolphinEmu.pinvoke.OnScreenDisplayImports;

namespace DolphinEmu;

public static class OnScreenDisplay
{
    public enum Color : uint
    {
        Cyan = 0xFF00FFFF,
        Green = 0xFF00FF00,
        Red = 0xFFFF0000,
        Yellow = 0xFFFFFF30
    }

    public enum Duration : uint
    {
        Short = 2000,
        Normal = 5000,
        VeryLong = 10000
    }

    public static void AddMessage(string message, Duration ms, Color argb)
        => on_screen_display_add_message(message, (uint)ms, (uint)argb);
}
