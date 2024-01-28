using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static partial class AddressSpaceImports
{
    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr address_space_get_accessors(
        int addressSpace);

    [LibraryImport(DolphinLibrary.Name)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool address_space_accessors_is_valid_address(
        IntPtr accessors,
        uint address);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial byte address_space_accessors_read_u8(
        IntPtr accessors,
        uint address);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void address_space_accessors_write_u8(
        IntPtr accessors,
        uint address,
        byte value);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr address_space_accessors_begin(
        IntPtr accessors);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr address_space_accessors_end(
        IntPtr accessors);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial uint address_space_accessors_get_size(
        IntPtr accessors);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial uint address_space_accessors_search(
        IntPtr accessors,
        uint haystackOffset,
        IntPtr needleStart,
        uint needleSize,
        [MarshalAs(UnmanagedType.Bool)] bool forward,
        [MarshalAs(UnmanagedType.Bool)] out bool ok);
}
