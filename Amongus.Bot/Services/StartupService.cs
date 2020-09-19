using Amongus.Bot.Configuration;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Amongus.Bot.Services
{
    public class StartupService
    {
        private readonly DiscordSocketClient _discordSocketClient;
        private readonly CommandService _commandService;
        private readonly IServiceProvider _services;
        private readonly DiscordConfiguration _discordOptions;

        public StartupService(IServiceProvider services, DiscordSocketClient discordSocketClient, CommandService commandService, IOptions<DiscordConfiguration> discordOptions)
        {
            _services = services;
            _discordSocketClient = discordSocketClient;
            _commandService = commandService;
            _discordOptions = discordOptions.Value;

            _discordSocketClient.Log += LogAsync;
            _discordSocketClient.Ready += ReadyAsync;
        }

        public async Task StartAsync()
        {
            var discordToken = !string.IsNullOrEmpty(_discordOptions.Token) ? _discordOptions.Token : throw new Exception("Missing Discord Bot token");

            await _discordSocketClient.LoginAsync(TokenType.Bot, discordToken);
            await _discordSocketClient.StartAsync();

            await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        // The Ready event indicates that the client has opened a
        // connection and it is now safe to access the cache.
        private Task ReadyAsync()
        {
            Console.WriteLine($"{_discordSocketClient.CurrentUser} is connected!");

            return Task.CompletedTask;
        }
    }
}
