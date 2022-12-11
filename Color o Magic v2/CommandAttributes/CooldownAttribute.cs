using Discord;
using Discord.Interactions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Color_o_Magic_v2.CommandAttributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CooldownAttribute : PreconditionAttribute
{
    private readonly long _cooldownTime;
    private readonly Dictionary<ulong, long> _activeCooldowns = new();

    /// <summary>
    /// Sets a cooldown on the command.
    /// </summary>
    /// <param name="cooldownTime">Cooldown time is in milliseconds.</param>
    public CooldownAttribute(long cooldownTime = 5 * 1000) => _cooldownTime = cooldownTime;

    public override async Task<PreconditionResult> CheckRequirementsAsync(IInteractionContext context, ICommandInfo commandInfo, IServiceProvider serviceProvider)
    {
        // Owner bypasses cooldown
        var config = serviceProvider.GetRequiredService<IConfiguration>();
        if (context.User.Id.Equals(UInt64.Parse(config["BOT_OWNER_ID"] ?? "427388881214898177"))) return await Task.FromResult(PreconditionResult.FromSuccess());

        // Get the current time in milliseconds
        var currentTimeMs = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        // Remove all expired cooldowns
        foreach (var pair in _activeCooldowns.Where(cooldown => cooldown.Value <= currentTimeMs).ToList()) _activeCooldowns.Remove(pair.Key);

        // If user is in cooldown, return error
        if (_activeCooldowns.ContainsKey(context.User.Id))
        {
            await context.Interaction.RespondAsync("Still on cooldown.", ephemeral: true);
            return await Task.FromResult(PreconditionResult.FromError("Still on cooldown."));
        }

        // Add user to cooldown
        _activeCooldowns.Add(context.User.Id, currentTimeMs + _cooldownTime);
        return await Task.FromResult(PreconditionResult.FromSuccess());
    }
}