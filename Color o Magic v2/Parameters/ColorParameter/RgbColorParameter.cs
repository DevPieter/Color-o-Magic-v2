using System.Drawing;
using Color_o_Magic_v2.Utils;
using Discord.Interactions;

namespace Color_o_Magic_v2.Parameters.ColorParameter;

public class RgbColorParameter : ComplexParameter
{
    private readonly int _r;
    private readonly int _g;
    private readonly int _b;

    /// <summary>
    /// Get the color from the RGB values.
    /// </summary>
    public Color? Color => ColorHelper.FromRgb(_r, _g, _b);

    public RgbColorParameter(
        [Summary("red", "Red (0-255)"), MinValue(0), MaxValue(255)]
        int red,
        [Summary("green", "Green (0-255)"), MinValue(0), MaxValue(255)]
        int green,
        [Summary("blue", "Blue (0-255)"), MinValue(0), MaxValue(255)]
        int blue)
    {
        _r = red;
        _g = green;
        _b = blue;
    }

    public override Discord.Embed GetErrorEmbed()
    {
        // Get embed info
        var title = ResourceHelper.ReadResource("invalid_rgb_color.title");
        var description = ResourceHelper.ReadResource("invalid_rgb_color.description");

        // Create embed
        return EmbedHelper.GetBasicErrorEmbed(title, description).Build();
    }
}