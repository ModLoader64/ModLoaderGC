using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static partial class MemoryImports
{
    [LibraryImport(DolphinLibrary.Name)]
    public static partial uint memory_get_ram_size_real();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial uint memory_get_ram_size();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial uint memory_get_ram_mask();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial uint memory_get_fake_vmem_size();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial uint memory_get_fake_vmem_mask();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial uint memory_get_l1_cache_size();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial uint memory_get_l1_cache_mask();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial uint memory_get_exram_size_real();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial uint memory_get_exram_size();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial uint memory_get_exram_mask();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr memory_get_ram();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr memory_get_exram();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr memory_get_l1_cache();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr memory_get_fake_vmem();

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr memory_get_pointer(
        uint address);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial IntPtr memory_get_pointer_for_range(
        uint address,
        uint size);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial byte memory_read_u8(
        uint address);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void memory_write_u8(
        byte var,
        uint address);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial ushort memory_read_u16(
    uint address);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void memory_write_u16(
        ushort var,
        uint address);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial uint memory_read_u32(
    uint address);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void memory_write_u32(
        uint var,
        uint address);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial ulong memory_read_u64(
    uint address);

    [LibraryImport(DolphinLibrary.Name)]
    public static partial void memory_write_u64(
        ulong var,
        ulong address);
}
