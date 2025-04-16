using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TGBot.Models.commands
{
    public class AddTeam : command
    {
        public override string Name => "/addteam";

        public override async void  Execute(Message message, TelegramBotClient client)
        {
            {
                var chatId = message.Chat.Id;
                var messageId = message.MessageId;


                await client.SendTextMessageAsync(chatId, "Enter favotite name of team", replyMarkup: new ForceReplyMarkup { Selective = true });
            }
        }
    }
 }
