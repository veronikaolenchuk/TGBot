using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TGBot.Models.commands
{
    public class AddHero : command
    {
        public override string Name => "/addhero";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;


            await client.SendTextMessageAsync(chatId, "Enter favotite name of hero", replyMarkup: new ForceReplyMarkup { Selective = true });
        }
    }
}
