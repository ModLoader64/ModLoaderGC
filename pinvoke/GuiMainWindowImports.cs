using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static class GuiMainWindowImports
{
    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_main_window_create();

    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_main_window_destroy();

    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_main_window_show();
}
