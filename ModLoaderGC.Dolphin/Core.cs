using static DolphinEmu.pinvoke.CoreImports;

namespace DolphinEmu;

public enum CoreState
{
    Uninitialized,
    Paused,
    Running,
    Stopping,
    Starting
}

public static class Core
{
    public static double ActualEmulationSpeed
        => core_get_actual_emulation_speed();

    public static bool IsRunning
        => core_is_running();

    public static bool IsRunningAndStarted
        => core_is_running_and_started();

    public static bool IsRunningInCurrentThread
        => core_is_running_in_current_thread();

    public static bool IsCPUThread
        => core_is_cpu_thread();

    public static bool IsGPUThread
        => core_is_gpu_thread();

    public static bool IsHostThread
        => core_is_host_thread();

    public static CoreState State
        => core_get_state();

    public static void SaveScreenShot()
        => core_save_screenshot();

    public static void SaveScreenShot(string name)
        => core_save_screenshot_as(name);

    public static void DisplayMessage(string message, int timeInMs)
        => core_display_message(message, timeInMs);

    public delegate void VoidCallbackFunc();

    public static void RunAsCPUThread(VoidCallbackFunc function)
        => core_run_as_cpu_thread(function);

    public static void RunOnCPUThread(VoidCallbackFunc function, bool waitForCompletion)
        => core_run_on_cpu_thread(function, waitForCompletion);

    public delegate void StateChangedCallbackFunc(CoreState state);

    public static int AddOnStateChangedCallback(StateChangedCallbackFunc callback)
        => core_add_on_state_changed_callback(callback);

    public static bool RemoveOnStateChangedCallback(ref int handle)
        => core_remove_on_state_changed_callback(ref handle);

    public static void QueueHostJob(VoidCallbackFunc job, bool runDuringStop = false)
        => core_queue_host_job(job, runDuringStop);

    public static void HostDispatchJobs()
        => core_host_dispatch_jobs();

    public static void DoFrameStep()
        => core_do_frame_step();

    public static void SetFrameEndCallback(VoidCallbackFunc callback)
        => core_set_frame_end_callback(callback);

    public static void SetResetCallback(VoidCallbackFunc callback)
        => core_set_reset_callback(callback);
}
