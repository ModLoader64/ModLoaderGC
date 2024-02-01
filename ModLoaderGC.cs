using DolphinEmu;
using DolphinEmu.Gui;
using System.Reflection;
using System.Runtime.InteropServices;
using ModLoader.API;
using ImGuiNET;
using ModLoaderGC.Dolphin;
using System;

namespace ModLoaderGC;

[Binding("ModLoaderGC")]
public class ModLoaderGC : IBinding
{
    private static string rom = "rom.iso";

    private static void OnInitImGui(IntPtr context)
    {
        ImGui.SetCurrentContext(context);

        // cancel dumb scaling
        ImGui.GetIO().DisplayFramebufferScale.X = 1;
        ImGui.GetIO().DisplayFramebufferScale.Y = 1;
        ImGui.GetIO().FontGlobalScale = 1;
        ImGui.GetStyle().ScaleAllSizes(1);

        ImGui.GetIO().Fonts.AddFontFromFileTTF(Path.Join(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "Roboto-Regular.ttf"), 20);
    }

    private static void OnRenderImGui(IntPtr context)
    {
        ImGui.SetCurrentContext(context);
        GlobalCallbacks.OnVI();
    }

    public static void InitBinding()
    {
        Console.WriteLine("ModLoaderGC Init");

        using var loader = new DolphinLoader();

        // set ImGui callbacks
        Osd.SetImGuiInitCallback(OnInitImGui);
        Osd.SetImGuiRenderCallback(OnRenderImGui);


        Console.WriteLine("ModLoaderGC ImGui Initialized");

        // initialize application
        Application.SetApplicationDisplayName("modloader64");
        Application.SetUserDirectory("dolphin_data");
        Application.Initialize();

        Console.WriteLine("ModLoaderGC Init Finished");
    }

    public static void StartBinding()
    {
        Console.WriteLine("ModLoaderGC Start");
        // check "Source\Core\DolphinQt\Plugin\config.cpp" for a list of exposed properties
        // some config files are also located in "<user dir>\Config"
        Config.Set("display.renderToMain", true);
        
        // memory size
        Config.Set("core.ramOverrideEnable", true);
        Config.Set("core.mem1Size", 0x04000000U); //64MB RAM

        Console.WriteLine("ModLoaderGC Create Main Window");
        // initialize main window
        MainWindow.Create();
        MainWindow.Show();
        MainWindow.SetIconFromFile(Path.Join(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "icon.png"));
        Console.WriteLine("ModLoaderGC Finished Creating Main Window");
        MainWindow.StartGameFromFile(rom);
        Console.WriteLine($"ModLoaderGC Starting {rom}");

        // setup callbacks
        Console.WriteLine("ModLoaderGC Setting Up ML Callbacks");
        GlobalCallbacks.SetupCallbacks();
        Console.WriteLine("ModLoaderGC Finished Setting Up ML Callbacks");

        // run Dolphin non-blocking
        while (!Application.HasExited)
        {
            Application.ProcessEvents();
            Core.HostDispatchJobs();
        }

        MainWindow.Destroy();
        Application.Deinitialize();
    }

    public static void StopBinding()
    {
        throw new NotImplementedException();
    }

    public static void SetGameFile(string file)
    {
        rom = file;
    }

    public static bool ChangeGameFile(string file)
    {
        throw new NotImplementedException();
    }

    public static void TogglePause()
    {
        throw new NotImplementedException();
    }

    public static bool SaveState(string file)
    {
        throw new NotImplementedException();
    }

    public static bool LoadState(string file)
    {
        throw new NotImplementedException();
    }
}

internal class DolphinLoader : IDisposable
{
    private nint _dolphinDll = 0;
    private nint _cimguiDll = 0;

    private void LoadLibrary()
    {
        // explicitly load DLLs by their full path so the dll imports will load symbols from these DLLs
        _dolphinDll = NativeLibrary.Load(Path.Join(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "Dolphin.dll"),
            Assembly.GetExecutingAssembly(),
            DllImportSearchPath.UserDirectories);
        _cimguiDll = NativeLibrary.Load(Path.Join(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "cimgui.dll"),
            Assembly.GetExecutingAssembly(),
            DllImportSearchPath.UserDirectories);

        // tell Dolphin where its base directory is and where qt plugins are located
        Application.AddLibraryPath(Path.Join(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "QtPlugins"));
        Application.SetExeDirectory(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName);
    }

    private void UnloadLibrary()
    {
        NativeLibrary.Free(_dolphinDll);
        NativeLibrary.Free(_cimguiDll);
    }

    public DolphinLoader()
        => LoadLibrary();

    #region IDisposable
    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            UnloadLibrary();
            disposedValue = true;
        }
    }

    ~DolphinLoader()
        => Dispose(disposing: false);

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    #endregion
}
