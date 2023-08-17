using static DolphinEmu.pinvoke.AddressSpaceImports;

namespace DolphinEmu;

public static class AddressSpace
{
    public enum Type
    {
        Effective,
        Auxiliary,
        Physical,
        Mem1,
        Mem2,
        Fake
    }

    public static Accessors Of(Type addressSpace)
        => new(address_space_get_accessors((int)addressSpace));

    public class Accessors
    {
        private readonly IntPtr _instance;

        internal Accessors(IntPtr instance)
            => _instance = instance;

        public bool IsValidAddress(uint address)
            => address_space_accessors_is_valid_address(_instance, address);

        public byte ReadByte(uint address)
            => address_space_accessors_read_u8(_instance, address);

        public void WriteByte(uint address, byte value)
            => address_space_accessors_write_u8(_instance, address, value);

        public IntPtr Begin
            => address_space_accessors_begin(_instance);

        public IntPtr End
            => address_space_accessors_end(_instance);

        public uint Size
            => address_space_accessors_get_size(_instance);

        public uint? Search(uint haystackOffset, IntPtr needleStart, uint needleSize, bool forward)
        {
            var address = address_space_accessors_search(_instance, haystackOffset, needleStart, needleSize,
                forward, out var ok);
            return ok ? address : null;
        }
    }
}
