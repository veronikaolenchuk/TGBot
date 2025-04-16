using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TGBot.Client;

namespace TGBot.Models.commands
{
    public class FindHero : command
    {
        public override string Name => "/findhero";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;


            await client.SendTextMessageAsync(chatId, "Enter name of hero", replyMarkup: new ForceReplyMarkup { Selective = true });
        }

        
    }
}
