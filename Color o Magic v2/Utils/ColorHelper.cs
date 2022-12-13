using System.Drawing;

namespace Color_o_Magic_v2.Utils;

public static class ColorHelper
{
    private static readonly Random DefaultRandom = new();

    /// <summary>
    /// Converts rgb values to a <see cref="Color"/>.
    /// </summary>
    /// <param name="r">Red</param>
    /// <param name="g">Green</param>
    /// <param name="b">Blue</param>
    /// <returns>A <see cref="Color"/>.</returns>
    public static Color? FromRgb(int r, int g, int b)
    {
        try
        {
            return Color.FromArgb(r, g, b);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Converts a <see cref="Color"/> to an rgb a string.
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static string ToRgbString(this Color color) => $"{color.R}, {color.G}, {color.B}";

    /// <summary>
    /// Converts a hex string to a <see cref="Color"/>.
    /// </summary>
    /// <param name="hex">A hex string.</param>
    /// <returns>A <see cref="Color"/>.</returns>
    public static Color? FromHex(string hex)
    {
        if (!hex.StartsWith("#")) hex = "#" + hex;
        try
        {
            return ColorTranslator.FromHtml(hex);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// Converts a <see cref="Color"/> to a hex string.
    /// </summary>
    /// <param name="color"></param>
    /// <returns>A hex string.</returns>
    public static string ToHexString(this Color color) => $"#{color.R:X2}{color.G:X2}{color.B:X2}";

    /// <summary>
    /// Converts a <see cref="Color"/> to an rgba string.
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static string ToArgbString(this Color color) => $"{color.ToArgb()}";

    /// <summary>
    /// Generates a random <see cref="Color"/>.
    /// </summary>
    /// <param name="random">Use a custom (seeded) <see cref="Random"/>.</param>
    /// <returns>A random <see cref="Color"/>.</returns>
    public static Color GenerateRandom(Random? random = null)
    {
        random ??= DefaultRandom;
        return Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
    }

    /// <summary>
    /// Generates a gradient between two colors.
    /// </summary>
    /// <param name="start">The start <see cref="Color"/>.</param>
    /// <param name="end">The end <see cref="Color"/>.</param>
    /// <param name="steps">The number of steps between the colors.</param>
    /// <returns>An array of <see cref="Color"/>s.</returns>
    public static IEnumerable<Color> GenerateGradients(Color start, Color end, int steps)
    {
        var stepR = (end.R - start.R) / (double)(steps - 1);
        var stepG = (end.G - start.G) / (double)(steps - 1);
        var stepB = (end.B - start.B) / (double)(steps - 1);
        for (var step = 0; step < steps; step++) yield return Color.FromArgb(start.R + (int)(stepR * step), start.G + (int)(stepG * step), start.B + (int)(stepB * step));
    }
}