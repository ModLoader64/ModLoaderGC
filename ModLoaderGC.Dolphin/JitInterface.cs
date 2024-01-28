using static DolphinEmu.pinvoke.JitInterfaceImports;

namespace DolphinEmu;

public static class JitInterface
{
    public static void ClearCache()
        => jit_interface_clear_cache();

    public static void InvalidateICache(uint address, uint size, bool forced)
        => jit_interface_invalidate_icache(address, size, forced);

    public static void InvalidateICacheLine(uint address)
        => jit_interface_invalidate_icache_line(address);

    public static void InvalidateICacheLines(uint address, uint count)
        => jit_interface_invalidate_icache_lines(address, count);
}
