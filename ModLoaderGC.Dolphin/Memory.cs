using static DolphinEmu.pinvoke.MemoryImports;

namespace DolphinEmu;

public static class Memory
{
    public static uint RamSizeReal
        => memory_get_ram_size_real();

    public static uint RamSize
        => memory_get_ram_size();

    public static uint RamMask
        => memory_get_ram_mask();

    public static uint FakeVMemSize
        => memory_get_fake_vmem_size();

    public static uint FakeVMemMask
        => memory_get_fake_vmem_mask();

    public static uint L1CacheSize
        => memory_get_l1_cache_size();

    public static uint L1CacheMask
        => memory_get_l1_cache_mask();

    public static uint ExRamSizeReal
        => memory_get_exram_size_real();

    public static uint ExRamSize
        => memory_get_exram_size();

    public static uint ExRamMask
        => memory_get_exram_mask();

    public static IntPtr Ram
        => memory_get_ram();

    public static IntPtr ExRam
        => memory_get_exram();

    public static IntPtr L1Cache
        => memory_get_l1_cache();

    public static IntPtr FakeVMem
        => memory_get_fake_vmem();

    public static IntPtr GetPointer(uint address)
        => memory_get_pointer(address);

    public static IntPtr GetPointerForRange(uint address, uint size)
        => memory_get_pointer_for_range(address, size);

    public static byte ReadByte(uint address)
        => memory_read_u8(address);

    public static void WriteByte(uint address, byte value)
        => memory_write_u8(value, address);
}
