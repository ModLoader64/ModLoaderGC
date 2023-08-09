using static DolphinEmu.pinvoke.DupStringImports;
using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static class ConfigImports
{
    [DllImport(DolphinLibrary.Name)]
    public static extern IntPtr config_find_info_by_name(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport(DolphinLibrary.Name)]
    public static extern IntPtr config_find_info_by_location(
        int system,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string section,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string key);

    [DllImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool config_get_boolean(
        IntPtr property,
        bool uncached);

    [DllImport(DolphinLibrary.Name)]
    public static extern int config_get_integer(
        IntPtr property,
        bool uncached);

    [DllImport(DolphinLibrary.Name)]
    public static extern ushort config_get_unsigned16(
        IntPtr property,
        bool uncached);

    [DllImport(DolphinLibrary.Name)]
    public static extern uint config_get_unsigned32(
        IntPtr property,
        bool uncached);

    [DllImport(DolphinLibrary.Name)]
    public static extern float config_get_float(
        IntPtr property,
        bool uncached);

    [DllImport(DolphinLibrary.Name, EntryPoint = "config_get_string")]
    private static extern IntPtr _config_get_string(
        IntPtr property,
        bool uncached);

    public static string config_get_string(
        IntPtr property,
        bool uncached)
    {
        var ptr = _config_get_string(property, uncached);
        var str = Marshal.PtrToStringUTF8(ptr);
        dup_free(ptr);
        return str!;
    }

    [DllImport(DolphinLibrary.Name)]
    public static extern int config_get_enum(
        IntPtr property,
        bool uncached);

    [DllImport(DolphinLibrary.Name)]
    public static extern void config_set_boolean(
        IntPtr property,
        bool uncached,
        bool value);

    [DllImport(DolphinLibrary.Name)]
    public static extern void config_set_integer(
        IntPtr property,
        bool uncached,
        int value);

    [DllImport(DolphinLibrary.Name)]
    public static extern void config_set_unsigned16(
        IntPtr property,
        bool uncached,
        ushort value);

    [DllImport(DolphinLibrary.Name)]
    public static extern void config_set_unsigned32(
        IntPtr property,
        bool uncached,
        uint value);

    [DllImport(DolphinLibrary.Name)]
    public static extern void config_set_float(
        IntPtr property,
        bool uncached,
        float value);

    [DllImport(DolphinLibrary.Name)]
    public static extern void config_set_string(
        IntPtr property,
        bool uncached,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string value);

    [DllImport(DolphinLibrary.Name)]
    public static extern void config_set_enum(
        IntPtr property,
        bool uncached,
        int value);

    [DllImport(DolphinLibrary.Name)]
    public static extern IntPtr config_get_info_for_memcard_path(
        int slot);

    [DllImport(DolphinLibrary.Name)]
    public static extern IntPtr config_get_info_for_agp_cart_path(
        int slot);

    [DllImport(DolphinLibrary.Name)]
    public static extern IntPtr config_get_info_for_gci_path(
        int slot);

    [DllImport(DolphinLibrary.Name)]
    public static extern IntPtr config_get_info_for_gci_path_override(
        int slot);

    [DllImport(DolphinLibrary.Name)]
    public static extern IntPtr config_get_info_for_exi_device(
        int slot);

    [DllImport(DolphinLibrary.Name)]
    public static extern IntPtr config_get_info_for_si_device(
        int channel);

    [DllImport(DolphinLibrary.Name)]
    public static extern IntPtr config_get_info_for_adapter_rumble(
        int channel);

    [DllImport(DolphinLibrary.Name)]
    public static extern IntPtr config_get_info_for_simulate_konga(
        int channel);

    [DllImport(DolphinLibrary.Name)]
    public static extern IntPtr config_get_info_for_wiimote_source(
        int index);
}
