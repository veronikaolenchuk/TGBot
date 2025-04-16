using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TGBot.Client;
using TGBot.Response;
using Telegram.Bot.Types.ReplyMarkups;

namespace TGBot.Models.commands
{
    public class FindPlayer : command
    {


        public string name ;
        public override string Name => "/findplayer";
        
        public async override void Execute(Message message, TelegramBotClient client)
        { 
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;


            await client.SendTextMessageAsync(chatId, "Enter name of player", replyMarkup: new ForceReplyMarkup { Selective = true });
            //try
            //{

            //    var player = await apiClient.FindPlayer(name);
            //    await client.SendPhotoAsync(chatId, player.image, player.name);

            //}
            //catch(Exception e)
            //{
            //    await client.SendTextMessageAsync(chatId, "No such player was found");

            //}






        }
    }
}
