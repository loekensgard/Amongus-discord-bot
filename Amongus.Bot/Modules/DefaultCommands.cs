using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amongus.Bot.Modules
{
    [Name("DefaultCommands")]
    public class DefaultCommands : ModuleBase<SocketCommandContext>
    {
        [Command("eject", RunMode = RunMode.Async)]
        [Summary("Who should be ejected?")]
        public async Task EjectCommand([Remainder]string inputNames)
        {
            var names = inputNames.Split(" ");

            var random = new Random();
            int index = random.Next(names.Length);
            var chosen = names[index];

            var embed = new EmbedBuilder
            {
                Color = Color.DarkRed,
                Description = $"Eject **{chosen}**!"
            };

            await ReplyAsync(null, false, embed.Build());
        }

        [Command("help", RunMode = RunMode.Async)]
        [Summary("Get help")]
        public async Task HelpCommand()
        {
            var embed = new EmbedBuilder
            {
                Color = Color.Green,
                Description = $"```Q - Kill{Environment.NewLine}R - Report" +
                $"{Environment.NewLine}E - Interact{Environment.NewLine}WASD - Walk" +
                $"{Environment.NewLine}Space - Interact{Environment.NewLine}Mouse 1 - Interact```"
            };

            embed.WithFooter(footer => footer.Text = "Turn on Mouse + keyboard");

            await ReplyAsync(null, false, embed.Build());
        }

        [Command("maps", RunMode = RunMode.Async)]
        [Summary("Get help")]
        public async Task MapsCommand([Remainder]string map = "")
        {
            var skeld = "https://vignette.wikia.nocookie.net/among-us-wiki/images/4/4f/SKELD_MAP.jpg/revision/latest";
            var polus = "https://vignette.wikia.nocookie.net/among-us-wiki/images/4/4c/Polus.png/revision/latest";
            var mira = "https://vignette.wikia.nocookie.net/among-us-wiki/images/0/0a/Mirahq.png/revision/latest";

            var skeldEmbed = new EmbedBuilder
            {
                Title = "The Skeld",
                ImageUrl = skeld
            };

            var polusEmbed = new EmbedBuilder
            {
                Title = "Polus",
                ImageUrl = polus
            };

            var miraEmbed = new EmbedBuilder
            {
                Title = "Mira HQ",
                ImageUrl = mira
            };

            switch (map.ToLower().Trim())
            {
                case "the skeld":
                    await ReplyAsync(null, false, skeldEmbed.Build());
                    break;
                case "skeld":
                    await ReplyAsync(null, false, skeldEmbed.Build());
                    break;
                case "polus":
                    await ReplyAsync(null, false, polusEmbed.Build());
                    break;
                case "mira":
                    await ReplyAsync(null, false, miraEmbed.Build());
                    break;
                case "mira hq":
                    await ReplyAsync(null, false, miraEmbed.Build());
                    break;
                default:
                    await ReplyAsync(null, false, skeldEmbed.Build());
                    await ReplyAsync(null, false, polusEmbed.Build());
                    await ReplyAsync(null, false, miraEmbed.Build());
                    break;
            }            
        }


    }
}
