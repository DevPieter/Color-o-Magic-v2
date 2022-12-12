using Color_o_Magic_v2.Attributes;
using Discord.Interactions;

namespace Color_o_Magic_v2.Interactions.Commands;

public class HelloWorldCommand : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("hello", "Says hello to you"), Cooldown(5 * 60 * 1000)]
    public async Task OnHello() => await RespondAsync("Hello World!", ephemeral: true);
}