using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static partial class StateImports
{
    [LibraryImport(DolphinLibrary.Name)]
    public static partial void state_save(
        int slot,
        [MarshalAs(UnmanagedType.Bool)] bool wait);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void state_load(
        int slot);

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void state_save_as(
        string filename,
        [MarshalAs(UnmanagedType.Bool)] bool wait);

    [LibraryImport(DolphinLibrary.Name, StringMarshalling = StringMarshalling.Utf8)]
    public static partial void state_load_as(
        string filename);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void state_save_to_buffer(
        out IntPtr data,
        out ulong size);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void state_load_from_buffer(
        IntPtr data,
        ulong size);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void state_free_buffer_data(
        IntPtr data);
}
