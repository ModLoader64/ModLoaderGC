using static DolphinEmu.pinvoke.gui_main_window;

namespace DolphinEmu.Gui;

public static class MainWindow
{
    public static void Create()
        => gui_main_window_create();

    public static void Destroy()
        => gui_main_window_destroy();

    public static void Show()
        => gui_main_window_show();
}
