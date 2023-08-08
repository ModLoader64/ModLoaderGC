using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static class core
{
    [DllImport(DolphinLibrary.Name)]
    public static extern double core_get_actual_emulation_speed();

    [DllImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool core_is_running();

    [DllImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool core_is_running_and_started();

    [DllImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool core_is_running_in_current_thread();

    [DllImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool core_is_cpu_thread();

    [DllImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool core_is_gpu_thread();

    [DllImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool core_is_host_thread();

    [DllImport(DolphinLibrary.Name)]
    public static extern CoreState core_get_state();

    [DllImport(DolphinLibrary.Name)]
    public static extern void core_save_screenshot();

    [DllImport(DolphinLibrary.Name)]
    public static extern void core_save_screenshot_as(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport(DolphinLibrary.Name)]
    public static extern void core_display_message(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string message,
        int time_in_ms);

    [DllImport(DolphinLibrary.Name)]
    public static extern void core_run_as_cpu_thread(
        Core.VoidCallbackFunc function);

    [DllImport(DolphinLibrary.Name)]
    public static extern void core_run_on_cpu_thread(
        Core.VoidCallbackFunc function,
        bool wait_for_completion);

    [DllImport(DolphinLibrary.Name)]
    public static extern int core_add_on_state_changed_callback(
        Core.StateChangedCallbackFunc callback);

    [DllImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool core_remove_on_state_changed_callback(
        ref int handle);

    [DllImport(DolphinLibrary.Name)]
    public static extern void core_queue_host_job(
        Core.VoidCallbackFunc job,
        bool run_during_stop);

    [DllImport(DolphinLibrary.Name)]
    public static extern void core_host_dispatch_jobs();

    [DllImport(DolphinLibrary.Name)]
    public static extern void core_do_frame_step();
}
