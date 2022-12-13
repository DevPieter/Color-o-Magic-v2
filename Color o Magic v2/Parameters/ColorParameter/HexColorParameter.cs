using System.Drawing;
using Color_o_Magic_v2.Utils;
using Discord.Interactions;

namespace Color_o_Magic_v2.Parameters.ColorParameter;

public class HexColorParameter : ComplexParameter
{
    private readonly string _hex;
    public Color? Color => ColorHelper.FromHex(_hex);

    public HexColorParameter([Summary("hex", "Hex color code"), MinLength(3), MaxLength(7)] string hex) => _hex = hex;

    public override Discord.Embed GetErrorEmbed()
    {
        var title = ResourceHelper.ReadResource("invalid_hex_color.title");
        var description = ResourceHelper.ReadResource("invalid_hex_color.description");

        return EmbedHelper.GetBasicErrorEmbed(title, description).Build();
    }
}