using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static partial class GuiApplicationImports
{
    [LibraryImport(DolphinLibrary.Name)]
    public static partial void gui_application_init();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void gui_application_deinit();

    [LibraryImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool gui_application_has_exited();

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf16)]
    public static partial void gui_application_set_organization_domain(
        string domain);

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf16)]
    public static partial void gui_application_set_organization_name(
        string name);

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf16)]
    public static partial void gui_application_set_application_name(
        string name);

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf16)]
    public static partial void gui_application_set_application_version(
        string version);

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf16)]
    public static partial void gui_application_set_application_display_name(
        string name);

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf16)]
    public static partial void gui_application_set_desktop_filename(
        string name);

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf16)]
    public static partial void gui_application_add_library_path(
        string path);

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void gui_application_set_exe_directory(
        string path);

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void gui_application_set_user_directory(
        string path);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial int gui_application_exec();

    [LibraryImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool gui_application_process_events();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void gui_application_quit();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void gui_application_exit(
        int retcode);
}
