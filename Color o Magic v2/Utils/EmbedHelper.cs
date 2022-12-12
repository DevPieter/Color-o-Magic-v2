﻿using System.Drawing;

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
            .WithTitle(title)
            .WithDescription(description)
            .WithColor(new Discord.Color(color.R, color.G, color.B));
    }
    
    /// <summary>
    /// Generates a basic embed with the given title and description.
    /// </summary>
    /// <param name="title">Embed title</param>
    /// <param name="description">Embed description</param>
    public static Discord.EmbedBuilder GetBasicEmbed(string title, string description) =>
        GetBasicEmbed(title, description, Color.FromArgb(205, 101, 109));

    /// <summary>
    /// Generates a basic Info embed with the given title and description.
    /// </summary>
    /// <param name="title">Embed title</param>
    /// <param name="description">Embed description</param>
    public static Discord.EmbedBuilder GetBasicInfoEmbed(string title, string description) =>
        GetBasicEmbed(title, description, Color.FromArgb(0, 255, 255));
    
    /// <summary>
    /// Generates a basic Success embed with the given title and description.
    /// </summary>
    /// <param name="title">Embed title</param>
    /// <param name="description">Embed description</param>
    public static Discord.EmbedBuilder GetBasicSuccessEmbed(string title, string description) =>
        GetBasicEmbed(title, description, Color.FromArgb(0, 255, 0));
    
    /// <summary>
    /// Generates a basic Error embed with the given title and description.
    /// </summary>
    /// <param name="title">Embed title</param>
    /// <param name="description">Embed description</param>
    public static Discord.EmbedBuilder GetBasicErrorEmbed(string title, string description) =>
        GetBasicEmbed(title, description, Color.FromArgb(255, 0, 0));
    
    /// <summary>
    /// Generates a basic Warning embed with the given title and description.
    /// </summary>
    /// <param name="title">Embed title</param>
    /// <param name="description">Embed description</param>
    public static Discord.EmbedBuilder GetBasicWarningEmbed(string title, string description) =>
        GetBasicEmbed(title, description, Color.FromArgb(255, 255, 0));
}