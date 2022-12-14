using System.Drawing;
using Color_o_Magic_v2.Utils;

namespace Color_o_Magic_v2.Templates;

public static class EmbedTemplates
{
    public static Discord.EmbedBuilder GetColorInfoEmbed(Color color)
    {
        var embed = EmbedHelper.GetColoredEmbed(color);
        embed.AddField("Hex", $"`{color.ToHexString()}`", true);
        embed.AddField("Rgb", $"`{color.ToRgbString()}`", true);
        embed.AddField("Argb", $"`{color.ToArgbString()}`", true);

        return embed;
    }
}