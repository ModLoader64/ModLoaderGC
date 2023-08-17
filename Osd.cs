using static DolphinEmu.pinvoke.OsdImports;

namespace DolphinEmu;

public static class Osd
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
        => osd_add_message(message, (uint)ms, (uint)argb);

    public delegate void ImGuiCallbackFunc(IntPtr context);

    public static void SetImGuiInitCallback(ImGuiCallbackFunc callback)
        => osd_set_imgui_init_callback(callback);

    public static void SetImGuiRenderCallback(ImGuiCallbackFunc callback)
        => osd_set_imgui_render_callback(callback);
}
