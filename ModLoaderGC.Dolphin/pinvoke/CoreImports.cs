using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static partial class CoreImports
{
    [LibraryImport(DolphinLibrary.Name)]
    public static partial double core_get_actual_emulation_speed();

    [LibraryImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool core_is_running();

    [LibraryImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool core_is_running_and_started();

    [LibraryImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool core_is_running_in_current_thread();

    [LibraryImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool core_is_cpu_thread();

    [LibraryImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool core_is_gpu_thread();

    [LibraryImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool core_is_host_thread();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial CoreState core_get_state();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void core_save_screenshot();

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void core_save_screenshot_as(
        string name);

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void core_display_message(
        string message,
        int timeInMs);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void core_run_as_cpu_thread(
        Core.VoidCallbackFunc function);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void core_run_on_cpu_thread(
        Core.VoidCallbackFunc function,
        [MarshalAs(UnmanagedType.Bool)] bool waitForCompletion);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial int core_add_on_state_changed_callback(
        Core.StateChangedCallbackFunc callback);

    [LibraryImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool core_remove_on_state_changed_callback(
        ref int handle);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void core_queue_host_job(
        Core.VoidCallbackFunc job,
        [MarshalAs(UnmanagedType.Bool)] bool runDuringStop);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void core_host_dispatch_jobs();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void core_do_frame_step();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void core_set_frame_end_callback(
        Core.VoidCallbackFunc callback);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void core_set_reset_callback(
        Core.VoidCallbackFunc callback);
}
