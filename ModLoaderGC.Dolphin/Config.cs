using static DolphinEmu.pinvoke.ConfigImports;

namespace DolphinEmu;

internal enum ConfigSystem
{
    Main,
    SYSCONF,
    GCPad,
    WiiPad,
    GCKeyboard,
    GFX,
    Logger,
    Debugger,
    DualShockUDPClient,
    FreeLook,
    Session,
    GameSettingsOnly,
    Achievements
}

public static class Config
{
    public class PropertyNotFoundException : Exception
    {
        public string Name { get; }

        public PropertyNotFoundException(string name)
            : base($"Property not found: `{name}`")
            => Name = name;
    }

    public class CallablePropertyNotFoundException : Exception
    {
        public string Name { get; }

        public CallablePropertyNotFoundException(string name)
            : base($"Callable property not found: `{name}`")
            => Name = name;
    }

    public class ConfigSystemNotFoundException : Exception
    {
        public string Name { get; }

        public ConfigSystemNotFoundException(string name)
            : base($"Config system not found: `{name}`")
            => Name = name;
    }

    public class InvalidPropertyTypeException : Exception
    {
        public string Name { get; }
        public Type Type { get; }

        public InvalidPropertyTypeException(string name, Type type)
            : base($"Invalid property type: `{name}`:{type}")
        {
            Name = name;
            Type = type;
        }
    }

    private static ConfigSystem GetConfigSystemFromString(string name)
        => name.ToUpperInvariant() switch
        {
            "MAIN" => ConfigSystem.Main,
            "SYSCONF" => ConfigSystem.SYSCONF,
            "GCPAD" => ConfigSystem.GCPad,
            "WIIPAD" => ConfigSystem.WiiPad,
            "GCKEYBOARD" => ConfigSystem.GCKeyboard,
            "GFX" => ConfigSystem.GFX,
            "LOGGER" => ConfigSystem.Logger,
            "DEBUGGER" => ConfigSystem.Debugger,
            "DUALSHOCKUDPCLIENT" => ConfigSystem.DualShockUDPClient,
            "FREELOOK" => ConfigSystem.FreeLook,
            "SESSION" => ConfigSystem.Session,
            "GAMESETTINGSONLY" => ConfigSystem.GameSettingsOnly,
            "ACHIEVEMENTS" => ConfigSystem.Achievements,
            _ => throw new ConfigSystemNotFoundException(name)
        };

    private static IntPtr FindProperty(string name, out bool uncached, params object[] args)
    {
        var baseName = name;
        var property = IntPtr.Zero;
        uncached = !name.StartsWith('-');
        if (!uncached) name = name[1..];
        var callable = name.StartsWith('@');
        if (callable) name = name[1..];

        if (!callable)
        {
            var commaIndex = name.IndexOf(',');
            var periodIndex = name.IndexOf('.');

            if (commaIndex < 0 && periodIndex < 0)
                property = config_find_info_by_name(name);
            else if (commaIndex > -1 && periodIndex > 0)
            {
                var system = GetConfigSystemFromString(name[..commaIndex]);
                var section = name.Substring(commaIndex + 1, periodIndex - commaIndex - 1);
                var key = name[(periodIndex + 1)..];
                property = config_find_info_by_location((int)system, section, key);
            }
            else if (periodIndex > -1)
            {
                var section = name[..periodIndex];
                var key = name[(periodIndex + 1)..];
                property = config_find_info_by_location(-1, section, key);
            }
        }
        else if (args.Length > 0)
        {
            var arg0 = (int)args[0];
            property = name.ToUpperInvariant() switch
            {
                "MEMCARDPATH" => config_get_info_for_memcard_path(arg0),
                "AGPCARTPATH" => config_get_info_for_agp_cart_path(arg0),
                "GCIPATH" => config_get_info_for_gci_path(arg0),
                "GCIPATHOVERRIDE" => config_get_info_for_gci_path_override(arg0),
                "EXIDEVICE" => config_get_info_for_exi_device(arg0),
                "SIDEVICE" => config_get_info_for_si_device(arg0),
                "ADAPTERRUMBLE" => config_get_info_for_adapter_rumble(arg0),
                "SIMULATEKONGA" => config_get_info_for_simulate_konga(arg0),
                "WIIMOTESOURCE" => config_get_info_for_wiimote_source(arg0),
                _ => throw new CallablePropertyNotFoundException(baseName)
            };
        }

        if (property == IntPtr.Zero)
            throw new PropertyNotFoundException(baseName);
        return property;
    }

    public static T Get<T>(string name, params object[] args)
    {
        var property = FindProperty(name, out var uncached, args);
        if (typeof(T) == typeof(bool))
            return (T)(object)config_get_boolean(property, uncached);
        if (typeof(T) == typeof(int))
            return (T)(object)config_get_integer(property, uncached);
        if (typeof(T) == typeof(ushort))
            return (T)(object)config_get_unsigned16(property, uncached);
        if (typeof(T) == typeof(uint))
            return (T)(object)config_get_unsigned32(property, uncached);
        if (typeof(T) == typeof(float))
            return (T)(object)config_get_float(property, uncached);
        if (typeof(T) == typeof(string))
            return (T)(object)config_get_string(property, uncached);
        if (typeof(T).IsEnum)
            return (T)(object)config_get_enum(property, uncached);
        throw new InvalidPropertyTypeException(name, typeof(T));
    }

    public static void Set<T>(string name, T value, params object[] args)
    {
        var property = FindProperty(name, out var uncached, args);
        switch (value)
        {
            case bool boolValue:
                config_set_boolean(property, uncached, boolValue);
                break;
            case int intValue:
                config_set_integer(property, uncached, intValue);
                break;
            case ushort u16Value:
                config_set_unsigned16(property, uncached, u16Value);
                break;
            case uint u32Value:
                config_set_unsigned32(property, uncached, u32Value);
                break;
            case float floatValue:
                config_set_float(property, uncached, floatValue);
                break;
            case string stringValue:
                config_set_string(property, uncached, stringValue);
                break;
            case Enum:
                config_set_enum(property, uncached, Convert.ToInt32(value));
                break;
            default:
                throw new InvalidPropertyTypeException(name, typeof(T));
        }
    }
}
