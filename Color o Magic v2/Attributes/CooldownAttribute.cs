using System.Resources;
using Color_o_Magic_v2.Utils;
using Discord;
using Discord.Interactions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Color_o_Magic_v2.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CooldownAttribute : PreconditionAttribute
{
    private readonly long _cooldownTime;
    private readonly Dictionary<ulong, long> _activeCooldowns = new();

    /// <summary>
    /// Sets a cooldown on the command.
    /// </summary>
    /// <param name="cooldownTime">A cooldown in milliseconds.</param>
    public CooldownAttribute(long cooldownTime = 5 * 1000) => _cooldownTime = cooldownTime;

    public override async Task<PreconditionResult> CheckRequirementsAsync(IInteractionContext context, ICommandInfo commandInfo, IServiceProvider serviceProvider)
    {
        var userId = context.User.Id;

        // Owner bypasses the cooldown
        var config = serviceProvider.GetRequiredService<IConfiguration>();
        if (userId.ToString().Equals(config["BOT_OWNER_ID"] ?? "427388881214898177")) return await Task.FromResult(PreconditionResult.FromSuccess());

        // Get the current time in milliseconds
        var currentTimeMs = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        // Remove all expired cooldowns
        foreach (var pair in _activeCooldowns.Where(cooldown => cooldown.Value <= currentTimeMs).ToList()) _activeCooldowns.Remove(pair.Key);

        // If user is in cooldown, return error
        if (_activeCooldowns.ContainsKey(userId))
        {
            // Get the remaining time
            var remainingTime = TimeSpan.FromMilliseconds(_activeCooldowns[userId] - currentTimeMs);

            // Get embed info
            var title = ResourceHelper.ReadResource("on_cooldown.title");
            var description = ResourceHelper.ReadResource("on_cooldown.description", "", remainingTime.Minutes, remainingTime.Seconds);

            // Create embed
            var embed = EmbedHelper.GetBasicErrorEmbed(title, description).Build();

            // Send embed
            await context.Interaction.RespondAsync(embed: embed, ephemeral: true);
            return await Task.FromResult(PreconditionResult.FromError("Still on cooldown."));
        }

        // Add user to cooldown
        _activeCooldowns.Add(userId, currentTimeMs + _cooldownTime);
        return await Task.FromResult(PreconditionResult.FromSuccess());
    }
}