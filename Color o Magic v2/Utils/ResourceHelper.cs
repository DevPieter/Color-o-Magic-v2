using System.Reflection;
using System.Resources;

namespace Color_o_Magic_v2.Utils;

public static class ResourceHelper
{
    private static readonly ResourceManager ResourceManager = new("Color_o_Magic_v2.Resources.Strings", Assembly.GetExecutingAssembly());
    
    /// <summary>
    /// Gets a string from the resource file.
    /// </summary>
    /// <param name="key">Key value</param>
    /// <param name="fallback">Fallback value for when the key could not be found.</param>
    /// <param name="args">String formatting args.</param>
    public static string ReadResource(string key, string fallback = "", params object?[] args) => string.Format(ResourceManager.GetString(key) ?? fallback, args);
}