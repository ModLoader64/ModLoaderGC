using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static partial class OnScreenDisplayImports
{
    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void on_screen_display_add_message(
        string message,
        uint ms,
        uint argb);
}
