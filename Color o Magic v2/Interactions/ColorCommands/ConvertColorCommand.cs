using System.Drawing;
using Color_o_Magic_v2.Attributes;
using Color_o_Magic_v2.Parameters.ColorParameter;
using Color_o_Magic_v2.Utils;
using Discord.Interactions;

namespace Color_o_Magic_v2.Interactions.ColorCommands;

[Group("convert", "Converts a color from one format to another."), Cooldown]
public class ConvertColorCommand : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("hex", "Converts a Hex color.")]
    public async Task OnHex([ComplexParameter] HexColorParameter hexColorParameter)
    {
        // Get the color from the parameter
        var color = hexColorParameter.Color;

        // Check if the user entered a valid color
        if (color != null) await OnConvertColor((Color)color);
        else await RespondAsync(embed: hexColorParameter.GetErrorEmbed(), ephemeral: true);
    }

    [SlashCommand("rgb", "Converts a RGB color.")]
    public async Task OnRgb([ComplexParameter] RgbColorParameter rgbColorParameter)
    {
        // Get the color from the parameter
        var color = rgbColorParameter.Color;

        // Check if the user entered a valid color
        if (color != null) await OnConvertColor((Color)color);
        else await RespondAsync(embed: rgbColorParameter.GetErrorEmbed(), ephemeral: true);
    }

    // [SlashCommand("hsl", "Converts a HSL color.")]
    // public async Task OnHsl()
    // {
    //     
    // }
    //
    // [SlashCommand("hsv", "Converts a HSV color.")]
    // public async Task OnHsv()
    // {
    //     
    // }

    private async Task OnConvertColor(Color color)
    {
        // Create embed
        var embed = EmbedHelper.GetColoredEmbed(color);
        embed.AddField("Hex", $"`{color.ToHexString()}`", true);
        embed.AddField("Rgb", $"`{color.ToRgbString()}`", true);
        embed.AddField("Argb", $"`{color.ToArgbString()}`", true);
        
        // Send embed
        await RespondAsync(embed: embed.Build());
    }
}