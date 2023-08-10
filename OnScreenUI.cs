using static DolphinEmu.pinvoke.OnScreenUIImports;

namespace DolphinEmu;

public static class OnScreenUI
{
    public delegate void ImGuiHookCallbackFunc(IntPtr context);

    public static void SetImGuiInitCallback(ImGuiHookCallbackFunc callback)
        => on_screen_ui_set_imgui_init_callback(callback);

    public static void SetImGuiRenderCallback(ImGuiHookCallbackFunc callback)
        => on_screen_ui_set_imgui_render_callback(callback);
}
