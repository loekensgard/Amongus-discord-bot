using Discord;
using System;

namespace Amongus.Bot.Services
{
    public class EmbedService
    {
        public EmbedBuilder EmbedEject(string inputNames)
        {
            var names = inputNames.Split(" ");

            var random = new Random();
            int index = random.Next(names.Length);
            var chosen = names[index];

            return new EmbedBuilder
            {
                Color = Color.DarkRed,
                Description = $"Eject **{chosen}**!"
            };
        }

        public EmbedBuilder EmbedHelp()
        {
            return new EmbedBuilder
            {
                Title = "Commands",
                Description = $"```!keybinds{Environment.NewLine}!eject <name1, name2, name3 etc..>{Environment.NewLine}!maps <skeld / polus / mira>```",
                Color = Color.DarkBlue,
                Footer = new EmbedFooterBuilder { Text = "Bot improvements can be featured to Thorshi#6851" }
            };
        }

        public EmbedBuilder EmbedKeyBinds()
        {
            return new EmbedBuilder
            {
                Color = Color.Green,
                Description = $"```Everyone:{Environment.NewLine}R - Report" +
                $"{Environment.NewLine}E - Interact{Environment.NewLine}WASD - Walk" +
                $"{Environment.NewLine}Space - Interact{Environment.NewLine}Mouse 1 - Interact{Environment.NewLine}Tab - Map with tasks{Environment.NewLine}{Environment.NewLine}Imposters:" +
                $"{Environment.NewLine}Q - Kill{Environment.NewLine}E - Sabotage```",
                Footer = new EmbedFooterBuilder { Text = "Turn on Mouse + keyboard" }
            };
        }

        public EmbedBuilder EmbedBeta()
        {
            return new EmbedBuilder
            {
                Color = Color.Green,
                Description = $"```1. Right click Amoung us{Environment.NewLine}2. Click properties{Environment.NewLine}3. Click betas{Environment.NewLine}4. Choose version```"
            };
        }

        public EmbedBuilder EmbedTheSkeld()
        {
            var skeld = "https://vignette.wikia.nocookie.net/among-us-wiki/images/4/4f/SKELD_MAP.jpg/revision/latest";

            return new EmbedBuilder
            {
                Title = "The Skeld",
                ImageUrl = skeld
            };
        }

        public EmbedBuilder EmbedPolus()
        {
            var polus = "https://vignette.wikia.nocookie.net/among-us-wiki/images/4/4c/Polus.png/revision/latest";

            return new EmbedBuilder
            {
                Title = "Polus",
                ImageUrl = polus
            };
        }
        public EmbedBuilder EmbedMiraHQ()
        {
            var mira = "https://vignette.wikia.nocookie.net/among-us-wiki/images/0/0a/Mirahq.png/revision/latest";

            return new EmbedBuilder
            {
                Title = "Mira HQ",
                ImageUrl = mira
            };
        }
    }
}
