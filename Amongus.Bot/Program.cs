using Discord;
using Discord.WebSocket;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Amongus.Bot
{
    class Program
    {
        private readonly DiscordSocketClient _client;

        // Discord.Net heavily utilizes TAP for async, so we create
        // an asynchronous context from the beginning.
        static void Main(string[] args)
        {
            try
            {
                new Startup().StartAsync().GetAwaiter().GetResult();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name}: {e.Message}");
                Console.WriteLine(e.StackTrace);
            }
        }

        public Program()
        {
            // It is recommended to Dispose of a client when you are finished
            // using it, at the end of your app's lifetime.
            _client = new DiscordSocketClient();

            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;
            _client.MessageReceived += MessageReceivedAsync;
        }

        public async Task MainAsync()
        {
            // Tokens should be considered secret data, and never hard-coded.
            await _client.LoginAsync(TokenType.Bot, "NzU2ODk2NDAzMzY3OTE5NjQ4.X2YgtQ.tUb-kkciSUSU4LQrtqRwNsz7lY0");
            await _client.StartAsync();

            // Block the program until it is closed.
            await Task.Delay(Timeout.Infinite);
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
            Console.WriteLine($"{_client.CurrentUser} is connected!");

            return Task.CompletedTask;
        }

        // This is not the recommended way to write a bot - consider
        // reading over the Commands Framework sample.
        private async Task MessageReceivedAsync(SocketMessage message)
        {
            // The bot should never respond to itself.
            if (message.Author.Id == _client.CurrentUser.Id)
                return;

            if (message.Content == "!flip")
                await message.Channel.SendMessageAsync("heads!");
        }
    }
}
