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

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void gui_main_window_start_game_from_file(
        string path);
}
