using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static partial class ConfigImports
{
    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr config_find_info_by_name(
        string name);

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf8)]
    public static partial IntPtr config_find_info_by_location(
        int system,
        string section,
        string key);

    [LibraryImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool config_get_boolean(
        IntPtr property,
        [MarshalAs(UnmanagedType.Bool)] bool uncached);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial int config_get_integer(
        IntPtr property,
        [MarshalAs(UnmanagedType.Bool)] bool uncached);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial ushort config_get_unsigned16(
        IntPtr property,
        [MarshalAs(UnmanagedType.Bool)] bool uncached);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial uint config_get_unsigned32(
        IntPtr property,
        [MarshalAs(UnmanagedType.Bool)] bool uncached);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial float config_get_float(
        IntPtr property,
        [MarshalAs(UnmanagedType.Bool)] bool uncached);

    [LibraryImport(DolphinLibrary.Name, EntryPoint = "config_get_string")]
    private static partial IntPtr _config_get_string(
        IntPtr property,
        [MarshalAs(UnmanagedType.Bool)] bool uncached);

    public static string config_get_string(
        IntPtr property,
        bool uncached)
        => StringUtil.PtrToStringUtf8(_config_get_string(property, uncached));

    [LibraryImport(DolphinLibrary.Name)]
    public static partial int config_get_enum(
        IntPtr property,
        [MarshalAs(UnmanagedType.Bool)] bool uncached);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void config_set_boolean(
        IntPtr property,
        [MarshalAs(UnmanagedType.Bool)] bool uncached,
        [MarshalAs(UnmanagedType.Bool)] bool value);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void config_set_integer(
        IntPtr property,
        [MarshalAs(UnmanagedType.Bool)] bool uncached,
        int value);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void config_set_unsigned16(
        IntPtr property,
        [MarshalAs(UnmanagedType.Bool)] bool uncached,
        ushort value);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void config_set_unsigned32(
        IntPtr property,
        [MarshalAs(UnmanagedType.Bool)] bool uncached,
        uint value);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void config_set_float(
        IntPtr property,
        [MarshalAs(UnmanagedType.Bool)] bool uncached,
        float value);

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void config_set_string(
        IntPtr property,
        [MarshalAs(UnmanagedType.Bool)] bool uncached,
        string value);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void config_set_enum(
        IntPtr property,
        [MarshalAs(UnmanagedType.Bool)] bool uncached,
        int value);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr config_get_info_for_memcard_path(
        int slot);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr config_get_info_for_agp_cart_path(
        int slot);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr config_get_info_for_gci_path(
        int slot);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr config_get_info_for_gci_path_override(
        int slot);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr config_get_info_for_exi_device(
        int slot);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr config_get_info_for_si_device(
        int channel);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr config_get_info_for_adapter_rumble(
        int channel);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr config_get_info_for_simulate_konga(
        int channel);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr config_get_info_for_wiimote_source(
        int index);
}
