using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TGBot.Client;
namespace TGBot.Models.commands
{
    public class FindTeam : command
    {


   
        public override string Name => @$"/findteam";

        public async override void Execute(Message message, TelegramBotClient client)
        {


            
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;


            await client.SendTextMessageAsync(chatId, "Enter name of team", replyMarkup: new ForceReplyMarkup { Selective = true });



        }
    }
}
