﻿using Color_o_Magic_v2.CommandAttributes;
using Discord.Commands;
using Discord.Interactions;

namespace Color_o_Magic_v2.Interactions.Commands;

public class HelloWorldCommand : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("hello", "Says hello to you"), Cooldown]
    public async Task OnHello() => await RespondAsync("Hello World!", ephemeral: true);
}