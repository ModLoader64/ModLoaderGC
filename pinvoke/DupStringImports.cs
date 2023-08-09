using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static class DupStringImports
{
    [DllImport(DolphinLibrary.Name)]
    public static extern IntPtr dup_free(IntPtr str);
}
