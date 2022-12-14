using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Color_o_Magic_v2;

public class Program
{
    public static Task Main() => new Program().MainAsync();

    private async Task MainAsync()
    {
        // Load the environment variables from the .env file
        DotNetEnv.Env.Load();

        // Setup dependency injection
        using var host = Host
            .CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services
                    .AddSingleton(x => new DiscordSocketClient(new DiscordSocketConfig { GatewayIntents = GatewayIntents.None }))
                    .AddSingleton(x => new InteractionService(x.GetRequiredService<DiscordSocketClient>()))
                    .AddSingleton<InteractionHandler>();
            }).Build();

        // Run the client asynchronously
        await RunClientAsync(host);
    }

    private async Task RunClientAsync(IHost host)
    {
        using var serviceScope = host.Services.CreateScope();
        var serviceProvider = serviceScope.ServiceProvider;

        // Get services
        var client = serviceProvider.GetRequiredService<DiscordSocketClient>();
        var config = serviceProvider.GetRequiredService<IConfiguration>();

        // Initialize the interaction handler
        var interactions = serviceProvider.GetRequiredService<InteractionService>();
        await serviceProvider.GetRequiredService<InteractionHandler>().InitializeAsync();

        // Log messages to the console
        client.Log += LogAsync;
        interactions.Log += LogAsync;

        // Register the interactions when the client is ready
        client.Ready += async () =>
        {
            await interactions.RegisterCommandsToGuildAsync(ulong.Parse(config["TEST_SERVER_ID"] ?? ""));
            //await interactions.RegisterCommandsGloballyAsync();
        };

        // Login and connect to Discord
        await client.LoginAsync(TokenType.Bot, config["TOKEN"]);
        await client.StartAsync();

        // Set the activity of the bot
        await client.SetActivityAsync(ParseGame(config["ACTIVITY"], config["ACTIVITY_TYPE"]));

        await Task.Delay(-1);
    }

    private Task LogAsync(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    private Game ParseGame(string? activity, string? type) =>
        new Game(activity ?? "", Enum.TryParse(type, true, out ActivityType activityType) ? activityType : ActivityType.Playing);
}