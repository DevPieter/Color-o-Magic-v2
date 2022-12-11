using Discord.Commands;
using Discord.Interactions;

namespace Color_o_Magic_v2.Interactions.Commands;

public class HelloWorldCommand : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("hello", "Says hello to you")]
    public async Task OnHello() => await ReplyAsync("Hello World!");
}