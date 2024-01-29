using DolphinEmu;
using DolphinEmu.pinvoke;
using ModLoader.API;
using ModLoaderGC.API;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ModLoaderGC.Dolphin;

//using static Frontend;

public static class GlobalCallbacks {
    private delegate void FrameCallbackDelegate(int FrameCount);
    private delegate void ResetCallbackDelegate(bool HardReset);
    private delegate void CommonCallbackDelegate();

    // Binding event objects.
    private static readonly EventNewVi viEvent = new EventNewVi();
    private static readonly EventNewFrame frameEvent = new EventNewFrame(0);
    private static int frameCount = 0;

    public static unsafe void OnFrame(int FrameCount) {
        frameEvent.frame = FrameCount;
        PubEventBus.bus.PushEvent(frameEvent);
    }

    public static void OnVI() {
        PubEventBus.bus.PushEvent(viEvent);
    }

    public static void OnReset() {
        Logger.Info("Reset");
    }

    public static void OnPause() {
    }

    public static void SetupCallbacks()
    {
        Core.AddOnStateChangedCallback(state => {
            Console.WriteLine($"STATE CHANGED: {state}");
        });

        Core.SetFrameEndCallback(() => OnFrame(frameCount++));
        Core.SetResetCallback(() => OnReset());
    }

}

