using static DolphinEmu.pinvoke.gui_application;

namespace DolphinEmu.Gui;

public static class Application
{
    public static void Initialize()
        => gui_application_init();

    public static void Deinitialize()
        => gui_application_deinit();

    public static bool HasExited
        => gui_application_has_exited();

    public static void SetOrganizationDomain(string domain)
        => gui_application_set_organization_domain(domain);

    public static void SetOrganizationName(string name)
        => gui_application_set_organization_name(name);

    public static void SetApplicationName(string name)
        => gui_application_set_application_name(name);

    public static void SetApplicationVersion(string version)
        => gui_application_set_application_version(version);

    public static void SetApplicationDisplayName(string name)
        => gui_application_set_application_display_name(name);

    public static void SetDesktopFileName(string name)
        => gui_application_set_desktop_filename(name);

    public static void AddLibraryPath(string path)
        => gui_application_add_library_path(path);

    public static void SetExeDirectory(string path)
        => gui_application_set_exe_directory(path);

    public static void SetUserDirectory(string path)
        => gui_application_set_user_directory(path);

    public static int Exec()
        => gui_application_exec();

    public static bool ProcessEvents()
        => gui_application_process_events();

    public static void Quit()
        => gui_application_quit();

    public static void Exit(int retcode = 0)
        => gui_application_exit(retcode);
}
