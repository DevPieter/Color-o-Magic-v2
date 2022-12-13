using Color_o_Magic_v2.Attributes;
using Color_o_Magic_v2.Utils;
using Discord;
using Discord.Interactions;

namespace Color_o_Magic_v2.Interactions.Commands;

public class HelloWorldCommand : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("hello", "Says hello to you"), Cooldown(5 * 60 * 1000, false)]
    public async Task OnHello() => await RespondAsync("Hello World!", ephemeral: true);

    [SlashCommand("embed-test", "Sends an embed"), Cooldown(15 * 60 * 1000)]
    public async Task OnEmbedTest()
    {
        var basicEmbed = EmbedHelper.GetBasicEmbed(null, "Custom Color Basic Embed Test 123.", Color.Blue).Build();
        var basicEmbedNoColor = EmbedHelper.GetBasicEmbed(null, "No Color Basic Embed Test 123.").Build();
        var basicInfoEmbed = EmbedHelper.GetBasicInfoEmbed(null, "Basic Info Embed Test 123.").Build();
        var basicSuccessEmbed = EmbedHelper.GetBasicSuccessEmbed(null, "Basic Success Embed Test 123.").Build();
        var basicWarningEmbed = EmbedHelper.GetBasicWarningEmbed(null, "Basic Warning Embed Test 123.").Build();
        var basicErrorEmbed = EmbedHelper.GetBasicErrorEmbed(null, "Basic Error Embed Test 123.").Build();

        await RespondAsync(embeds: new[] { basicEmbed, basicEmbedNoColor, basicInfoEmbed, basicSuccessEmbed, basicWarningEmbed, basicErrorEmbed });
    }

    [SlashCommand("owner-test", "Owner test command"), RequiresOwner]
    public async Task OnOwnerTest() => await RespondAsync("Hello World!");
}