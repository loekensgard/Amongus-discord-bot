using Amongus.Bot.Configuration;
using Amongus.Bot.Services;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Amongus.Bot
{
    public class Startup
    {
        private IConfiguration _configuration { get; set; }

        public Startup()
        {
            var _builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.development.json", optional: true)
                .AddEnvironmentVariables();

            _configuration = _builder.Build();
        }

        public async Task StartAsync()
        {
            var startup = new Startup();
            await startup.RunAsync();
        }

        public async Task RunAsync()
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetRequiredService<CommandHandlerService>();

            await serviceProvider.GetRequiredService<StartupService>().StartAsync();
            await Task.Delay(Timeout.Infinite);
        }

        private IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = Discord.LogSeverity.Verbose,
                MessageCacheSize = 1000
            }));

            services.AddSingleton(new CommandService(new CommandServiceConfig
            {
                DefaultRunMode = RunMode.Async,
                LogLevel = Discord.LogSeverity.Verbose,
                CaseSensitiveCommands = false,
                ThrowOnError = false
            }));

            services.AddSingleton<CommandHandlerService>();
            services.AddSingleton<StartupService>();
            services.AddSingleton(_configuration);

            services.AddTransient<EmbedService>();

            services.Configure<DiscordConfiguration>(options => _configuration.GetSection("Discord-Amongus").Bind(options));

            return services;
        }

    }
}
