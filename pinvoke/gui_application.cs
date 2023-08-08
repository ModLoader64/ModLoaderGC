using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static class gui_application
{
    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_application_init();

    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_application_deinit();

    [DllImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool gui_application_has_exited();

    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_application_set_organization_domain(
        [MarshalAs(UnmanagedType.LPWStr)] string org_domain);

    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_application_set_organization_name(
        [MarshalAs(UnmanagedType.LPWStr)] string org_name);

    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_application_set_application_name(
        [MarshalAs(UnmanagedType.LPWStr)] string application);

    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_application_set_application_version(
        [MarshalAs(UnmanagedType.LPWStr)] string version);

    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_application_set_application_display_name(
        [MarshalAs(UnmanagedType.LPWStr)] string name);

    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_application_set_desktop_filename(
        [MarshalAs(UnmanagedType.LPWStr)] string name);

    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_application_add_library_path(
        [MarshalAs(UnmanagedType.LPWStr)] string path);

    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_application_set_exe_directory(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string path);

    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_application_set_user_directory(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string path);

    [DllImport(DolphinLibrary.Name)]
    public static extern int gui_application_exec();

    [DllImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool gui_application_process_events();

    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_application_quit();

    [DllImport(DolphinLibrary.Name)]
    public static extern void gui_application_exit(int retcode);
}
