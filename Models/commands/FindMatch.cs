using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TGBot.Models.commands
{
    public class FindMatch:command
    {
        public override string Name => "/findmatch";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;


            await client.SendTextMessageAsync(chatId, "Enter id of match", replyMarkup: new ForceReplyMarkup { Selective = true });

        }


    }
}
