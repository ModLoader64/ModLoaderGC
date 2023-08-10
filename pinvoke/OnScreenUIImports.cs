using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static partial class OnScreenUIImports
{
    [LibraryImport(DolphinLibrary.Name)]
    public static partial void on_screen_ui_set_imgui_init_callback(
        OnScreenUI.ImGuiHookCallbackFunc callback);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void on_screen_ui_set_imgui_render_callback(
        OnScreenUI.ImGuiHookCallbackFunc callback);
}
