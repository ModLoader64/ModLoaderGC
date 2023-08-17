using System.Runtime.InteropServices;
using static DolphinEmu.pinvoke.DupStringImports;

namespace DolphinEmu.pinvoke;

internal static class StringUtil
{
    public static string PtrToStringUtf8(IntPtr ptr)
    {
        var str = Marshal.PtrToStringUTF8(ptr);
        dup_free(ptr);
        return str!;
    }
}
