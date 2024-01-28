using static DolphinEmu.pinvoke.GuiMainWindowImports;

namespace DolphinEmu.Gui;

public static class MainWindow
{
    public static void Create()
        => gui_main_window_create();

    public static void Destroy()
        => gui_main_window_destroy();

    public static void Show()
        => gui_main_window_show();

    public static void SetIconFromFile(string path)
        => gui_main_window_set_icon_from_file(path);

    public static void StartGameFromFile(string path)
        => gui_main_window_start_game_from_file(path);
}
