using Amongus.Bot.Services;
using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace Amongus.Bot.Modules
{
    [Name("DefaultCommands")]
    public class DefaultCommands : ModuleBase<SocketCommandContext>
    {
        private readonly EmbedService _embedService;

        public DefaultCommands(EmbedService embedService)
        {
            _embedService = embedService;
        }

        [Command("eject", RunMode = RunMode.Async)]
        [Summary("Who should be ejected?")]
        public async Task EjectCommand([Remainder] string inputNames)
        {
            var builder = _embedService.EmbedEject(inputNames);

            await ReplyAsync(null, false, builder.Build());
        }

        

        [Command("help", RunMode = RunMode.Async)]
        [Summary("Get help")]
        public async Task HelpCommand()
        {
            var builder = _embedService.EmbedHelp();

            await ReplyAsync(null, false, builder.Build());
        }


        [Command("keybinds", RunMode = RunMode.Async)]
        [Summary("Get keybinds")]
        public async Task Keybinds()
        {
            var builder = _embedService.EmbedKeyBinds();

            await ReplyAsync(null, false, builder.Build());
        }


        [Command("maps", RunMode = RunMode.Async)]
        [Summary("Get maps")]
        public async Task MapsCommand([Remainder] string map = "")
        {
            switch (map.ToLower().Trim())
            {
                case "the skeld":
                    await ReplyAsync(null, false, _embedService.EmbedTheSkeld().Build());
                    break;
                case "skeld":
                    await ReplyAsync(null, false, _embedService.EmbedTheSkeld().Build());
                    break;
                case "polus":
                    await ReplyAsync(null, false, _embedService.EmbedPolus().Build());
                    break;
                case "mira":
                    await ReplyAsync(null, false, _embedService.EmbedMiraHQ().Build());
                    break;
                case "mira hq":
                    await ReplyAsync(null, false, _embedService.EmbedMiraHQ().Build());
                    break;
                default:
                    await ReplyAsync(null, false, _embedService.EmbedTheSkeld().Build());
                    await ReplyAsync(null, false, _embedService.EmbedPolus().Build());
                    await ReplyAsync(null, false, _embedService.EmbedMiraHQ().Build());
                    break;
            }
        }


    }
}
