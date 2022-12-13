using System.Drawing;

namespace Color_o_Magic_v2.Utils;

public static class EmbedHelper
{
    /// <summary>
    /// Generates a basic embed with the given title, description and color.
    /// </summary>
    /// <param name="title">Embed title</param>
    /// <param name="description">Embed description</param>
    /// <param name="color">Embed color</param>
    public static Discord.EmbedBuilder GetBasicEmbed(string? title, string? description, Color color)
    {
        return new Discord.EmbedBuilder()
            .WithTitle(title ?? ResourceHelper.ReadResource("name"))
            .WithDescription(description)
            .WithColor(new Discord.Color(color.R, color.G, color.B));
    }

    /// <summary>
    /// Generates a basic embed with the given title and description.
    /// </summary>
    /// <param name="title">Embed title</param>
    /// <param name="description">Embed description</param>
    public static Discord.EmbedBuilder GetBasicEmbed(string? title, string? description) =>
        GetBasicEmbed(title, description, Color.FromArgb(205, 101, 109));

    /// <summary>
    /// Generates a basic Info embed with the given title and description.
    /// </summary>
    /// <param name="title">Embed title</param>
    /// <param name="description">Embed description</param>
    public static Discord.EmbedBuilder GetBasicInfoEmbed(string? title, string? description) =>
        GetBasicEmbed(title ?? ResourceHelper.ReadResource("info"), description, Color.FromArgb(101, 134, 205));

    /// <summary>
    /// Generates a basic Success embed with the given title and description.
    /// </summary>
    /// <param name="title">Embed title</param>
    /// <param name="description">Embed description</param>
    public static Discord.EmbedBuilder GetBasicSuccessEmbed(string? title, string? description) =>
        GetBasicEmbed(title ?? ResourceHelper.ReadResource("success"), description, Color.FromArgb(101, 205, 104));

    /// <summary>
    /// Generates a basic Error embed with the given title and description.
    /// </summary>
    /// <param name="title">Embed title</param>
    /// <param name="description">Embed description</param>
    public static Discord.EmbedBuilder GetBasicErrorEmbed(string? title, string? description) =>
        GetBasicEmbed(title ?? ResourceHelper.ReadResource("error"), description, Color.FromArgb(205, 101, 101));

    /// <summary>
    /// Generates a basic Warning embed with the given title and description.
    /// </summary>
    /// <param name="title">Embed title</param>
    /// <param name="description">Embed description</param>
    public static Discord.EmbedBuilder GetBasicWarningEmbed(string? title, string? description) =>
        GetBasicEmbed(title ?? ResourceHelper.ReadResource("warning"), description, Color.FromArgb(205, 172, 101));

    /// <summary>
    /// Generates a empty embed with the given color.
    /// </summary>
    /// <param name="color">Embed color</param>
    public static Discord.EmbedBuilder GetColoredEmbed(Color color) =>
        new Discord.EmbedBuilder().WithColor(new Discord.Color(color.R, color.G, color.B));
}