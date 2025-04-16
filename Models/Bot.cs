using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using TGBot.Client;
using TGBot.Models.commands;
namespace TGBot.Models
{
    public static class Bot
    {
        
        private static List<command> commandsList;
        public static IReadOnlyList<command> Commands => commandsList.AsReadOnly();
        private static TelegramBotClient client;
        public static async Task<TelegramBotClient> Get()
        {


            if (client != null)
            {
                return client;
            }
            commandsList = new List<command>() {
            //new start(),
            //new help(),
            new FindPlayer(),
            new FindTeam(),
            new FindHero(),
            new help(),
            new FindMatch(),
            new AddTeam(),
            new AddPlayer(),
            new AddHero(),
            new AddMatch()
            };

            client = new TelegramBotClient(config.token);
            await client.SetWebhookAsync(config.hook);
            return client;
        }
    }
}
