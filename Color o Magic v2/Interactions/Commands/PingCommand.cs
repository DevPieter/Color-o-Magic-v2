using Color_o_Magic_v2.Attributes;
using Color_o_Magic_v2.Utils;
using Discord.Interactions;
using Discord.WebSocket;

namespace Color_o_Magic_v2.Interactions.Commands;

public class PingCommand : InteractionModuleBase<SocketInteractionContext>
{
    private readonly DiscordSocketClient _client;

    public PingCommand(DiscordSocketClient client) => _client = client;

    [SlashCommand("ping", "Pong!"), Cooldown]
    public async Task OnPing()
    {
        // Get embed info
        var title = ResourceHelper.ReadResource("ping.title");
        var description = ResourceHelper.ReadResource("ping.description", "{0:D}ms", _client.Latency);

        // Create embed
        var embed = EmbedHelper.GetBasicInfoEmbed(title, description).Build();

        // Reply with embed
        await RespondAsync(embed: embed, ephemeral: true);
    }
}