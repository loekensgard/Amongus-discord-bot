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
    }
}
