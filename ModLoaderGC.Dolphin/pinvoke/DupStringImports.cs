using System.Runtime.InteropServices;

namespace DolphinEmu.pinvoke;

internal static partial class DupStringImports
{
    [LibraryImport(DolphinLibrary.Name)]
    public static partial void dup_free(IntPtr str);
}
