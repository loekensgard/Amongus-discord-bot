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

    }
}
