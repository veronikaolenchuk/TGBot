using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TGBot.Models.commands
{
    public class help : command
    {
        public override string Name => "/help";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            string text = "Hello, This bot can: search for players(/findplayer), teams(/findteam), hero(/findhero), show the upcomming matches(/showmatches),find match by id(/findmatch) and add them to favorite(/addplayer,/addteam./addhero./addmatch), also show your favorite(/showfavorite)";

            await client.SendTextMessageAsync(chatId, text);

        }
    }
}
