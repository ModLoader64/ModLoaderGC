using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static partial class OsdImports
{
    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void osd_add_message(
        string message,
        uint ms,
        uint argb);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void osd_set_imgui_init_callback(
        Osd.ImGuiCallbackFunc callback);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void osd_set_imgui_render_callback(
        Osd.ImGuiCallbackFunc callback);
}
