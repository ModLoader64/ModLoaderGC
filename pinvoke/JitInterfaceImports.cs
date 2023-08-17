using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static partial class JitInterfaceImports
{
    [LibraryImport(DolphinLibrary.Name)]
    public static partial void jit_interface_clear_cache();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void jit_interface_invalidate_icache(
        uint address,
        uint size,
        [MarshalAs(UnmanagedType.Bool)] bool forced);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void jit_interface_invalidate_icache_line(
        uint address);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void jit_interface_invalidate_icache_lines(
        uint address,
        uint count);
}
