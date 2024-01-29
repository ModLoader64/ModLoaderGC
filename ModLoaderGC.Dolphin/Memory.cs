using ModLoader.API;
using System.Runtime.CompilerServices;
using static DolphinEmu.pinvoke.MemoryImports;

namespace DolphinEmu;

[BoundMemory]
public unsafe class Memory : IMemory
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

    /// <summary>
    /// Read an 8-bit integer value at address
    /// </summary>
    /// <param name="address">Where to read</param>
    /// <returns>Value read, 0 on error</returns>
    public static byte ReadU8(u64 address)
    {
        return memory_read_u8((uint)address);
    }

    /// <summary>
    /// Read an 16-bit integer value at address
    /// </summary>
    /// <param name="address">Where to read</param>
    /// <returns>Value read, 0 on error</returns>
    public static u16 ReadU16(u64 address)
    {
        return memory_read_u16((uint)address);
    }

    /// <summary>
    /// Read an 32-bit integer value at address
    /// </summary>
    /// <param name="address">Where to read</param>
    /// <returns>Value read, 0 on error</returns>
    public static u32 ReadU32(u64 address)
    {
        return memory_read_u32((uint)address);
    }

    /// <summary>
    /// Read an 64-bit integer value at address
    /// </summary>
    /// <param name="address">Where to read</param>
    /// <returns>Value read, 0 on error</returns>
    public static u64 ReadU64(u64 address)
    {
        return memory_read_u64((uint)address);
    }

    /// <summary>
    /// Read an 32-bit floating point value at address
    /// </summary>
    /// <param name="address">Where to read</param>
    /// <returns>Value read, 0 on error</returns>
    public static f32 ReadF32(u64 address)
    {
        return (f32)memory_read_u32((uint)address);
    }

    /// <summary>
    /// Read an 64-bit floating point value at address
    /// </summary>
    /// <param name="address">Where to read</param>
    /// <returns>Value read, 0 on error</returns>
    public static f64 ReadF64(u64 address)
    {
        return (f64)memory_read_u64((uint)address);
    }

    /// <summary>
    /// Write a 8-bit integer to memory address
    /// </summary>
    /// <param name="address">Where to write</param>
    /// <param name="value">Value to write</param>
    public static void WriteU8(u64 address, u8 value)
    {
        memory_write_u8(value, (uint)address);
    }

    /// <summary>
    /// Write a 16-bit integer to memory address
    /// </summary>
    /// <param name="address">Where to write</param>
    /// <param name="value">Value to write</param>
    public static void WriteU16(u64 address, u16 value)
    {
        memory_write_u16(value, (uint)address);
    }

    /// <summary>
    /// Write a 32-bit integer to memory address
    /// </summary>
    /// <param name="address">Where to write</param>
    /// <param name="value">Value to write</param>
    public static void WriteU32(u64 address, u32 value)
    {
        memory_write_u32(value, (uint)address);
    }

    /// <summary>
    /// Write a 64-bit integer to memory address
    /// </summary>
    /// <param name="address">Where to write</param>
    /// <param name="value">Value to write</param>
    public static void WriteU64(u64 address, u64 value)
    {
        memory_write_u64(value, (uint)address);
    }

    /// <summary>
    /// Write a 32-bit floating point value to memory address
    /// </summary>
    /// <param name="address">Where to write</param>
    /// <param name="value">Value to write</param>
    public static void WriteF32(u64 address, f32 value)
    {
        memory_write_u32((u32)value, (uint)address);
    }

    /// <summary>
    /// Write a 64-bit floating point value to memory address
    /// </summary>
    /// <param name="address">Where to write</param>
    /// <param name="value">Value to write</param>
    public static void WriteF64(u64 address, f64 value)
    {
        memory_write_u64((u64)value, (uint)address);
    }

    /// <summary>
    /// Write a primitive value of type T, with sizeof(T) to memory address
    /// </summary>
    /// <typeparam name="T">Primitive type</typeparam>
    /// <param name="address">Where to write</param>
    /// <param name="value">Value to write</param>
    public static void Write<T>(u64 address, T value) where T : unmanaged
    {
        if (!typeof(T).IsPrimitive)
        {
            throw new InvalidOperationException("T must be a primitive type!");
        }

        if (typeof(T) == typeof(f32))
        {
            WriteF32(address, (f32)(object)value);
        }
        else if (typeof(T) == typeof(f64))
        {
            WriteF64(address, (f64)(object)value);
        }
        else if (typeof(T) == typeof(u8))
        {
            WriteU8(address, (u8)(object)value);
        }
        else if (typeof(T) == typeof(s8))
        {
            WriteU8(address, (u8)((s8)(object)value));
        }
        else if (typeof(T) == typeof(u16))
        {
            WriteU16(address, (u16)(object)value);
        }
        else if (typeof(T) == typeof(s16))
        {
            WriteU16(address, (u16)((s16)(object)value));
        }
        else if (typeof(T) == typeof(u32))
        {
            WriteU32(address, (u32)(object)value);
        }
        else if (typeof(T) == typeof(s32))
        {
            WriteU32(address, (u32)((s32)(object)value));
        }
        else if (typeof(T) == typeof(u64))
        {
            WriteU64(address, (u64)(object)value);
        }
        else if (typeof(T) == typeof(s64))
        {
            WriteU64(address, (u64)((s64)(object)value));
        }
        else
        {
            throw new InvalidOperationException("Unsupported type!");
        }
    }

    /// <summary>
    /// Read a value of type T, with size sizeof(T) at memory address
    /// </summary>
    /// <typeparam name="T">Type of read value</typeparam>
    /// <param name="address">Address to read</param>
    /// <returns>Value read</returns>
    public static T Read<T>(u64 address) where T : unmanaged
    {
        if (!typeof(T).IsPrimitive)
        {
            throw new InvalidOperationException("T Must be a primitive type!");
        }

        int size = Unsafe.SizeOf<T>();
        if (typeof(T) == typeof(f32))
        {
            return (T)(object)ReadF32(address);
        }
        else if (typeof(T) == typeof(f64))
        {
            return (T)(object)ReadF64(address);
        }
        else
        {
            switch (size)
            {
                case 1:
                    return (T)(object)ReadU8(address);
                case 2:
                    return (T)(object)ReadU16(address);
                case 4:
                    return (T)(object)ReadU32(address);
                case 8:
                    return (T)(object)ReadU64(address);
                default:
                    throw new InvalidOperationException($"T has an invalid size? {size}");
            }
        }
    }

    public static sbyte ReadS8(ulong address)
    {
        return Convert.ToSByte(ReadU8(address));
    }

    public static short ReadS16(ulong address)
    {
        return Convert.ToInt16(ReadU16(address));
    }

    public static int ReadS32(ulong address)
    {
        return Convert.ToInt32(ReadU32(address));
    }

    public static long ReadS64(ulong address)
    {
        return Convert.ToInt64(ReadU64(address));
    }

    public static void WriteS8(ulong address, sbyte value)
    {
        Write(address, value);
    }

    public static void WriteS16(ulong address, short value)
    {
        Write(address, value);
    }

    public static void WriteS32(ulong address, int value)
    {
        Write(address, value);
    }

    public static void WriteS64(ulong address, long value)
    {
        Write(address, value);
    }

    public static void InvalidateCachedCode()
    {
        // TODO: Confirm if this needs adjusting
        JitInterface.InvalidateICache(0, 0, true);
    }
}
