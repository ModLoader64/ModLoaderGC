using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static partial class GuiMainWindowImports
{
    [LibraryImport(DolphinLibrary.Name)]
    public static partial void gui_main_window_create();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void gui_main_window_destroy();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void gui_main_window_show();
}
