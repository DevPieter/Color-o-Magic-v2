using Color_o_Magic_v2.Utils;
using Discord;
using Discord.Interactions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Color_o_Magic_v2.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class RequiresOwnerAttribute : PreconditionAttribute
{
    /// <summary>
    /// Checks if the user is the owner of the bot.
    /// </summary>
    public RequiresOwnerAttribute()
    {
    }

    public override async Task<PreconditionResult> CheckRequirementsAsync(IInteractionContext context, ICommandInfo commandInfo, IServiceProvider serviceProvider)
    {
        var userId = context.User.Id;

        // Get the owner ID from the config and check if the user is the owner
        var config = serviceProvider.GetRequiredService<IConfiguration>();
        if (userId.ToString().Equals(config["BOT_OWNER_ID"] ?? "427388881214898177")) return await Task.FromResult(PreconditionResult.FromSuccess());

        // Get embed info
        var title = ResourceHelper.ReadResource("not_the_owner.title");
        var description = ResourceHelper.ReadResource("not_the_owner.description");

        // Create embed
        var embed = EmbedHelper.GetBasicErrorEmbed(title, description).Build();

        // Send embed
        await context.Interaction.RespondAsync(embed: embed, ephemeral: true);
        return await Task.FromResult(PreconditionResult.FromError("Not the bot owner."));
    }
}