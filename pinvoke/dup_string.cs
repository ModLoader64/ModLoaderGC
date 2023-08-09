using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static class dup_string
{
    [DllImport(DolphinLibrary.Name)]
    public static extern IntPtr dup_free(IntPtr str);
}
