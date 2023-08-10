using static DolphinEmu.pinvoke.StateImports;

namespace DolphinEmu;

public static class State
{
    public static void Save(int slot, bool wait = false)
        => state_save(slot, wait);

    public static void Load(int slot)
        => state_load(slot);

    public static void SaveAs(string filename, bool wait = false)
        => state_save_as(filename, wait);

    public static void LoadAs(string filename)
        => state_load_as(filename);

    public sealed class Buffer : IDisposable
    {
        public IntPtr Data { get; }
        public ulong Size { get; }

        public Buffer(IntPtr data, ulong size)
        {
            Data = data;
            Size = size;
        }

        private void Free()
            => state_free_buffer_data(Data);

        public void Dispose()
        {
            Free();
            GC.SuppressFinalize(this);
        }

        ~Buffer()
            => Free();
    }

    public static Buffer SaveToBuffer()
    {
        state_save_to_buffer(out var data, out var size);
        return new Buffer(data, size);
    }

    public static void LoadFromBuffer(Buffer buffer)
        => state_load_from_buffer(buffer.Data, buffer.Size);
}
