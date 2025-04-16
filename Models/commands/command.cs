using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TGBot.Client;
namespace TGBot.Models.commands
{
    public abstract class command
    {
        public abstract string Name { get; }

        public abstract void Execute(Message message, TelegramBotClient client);
        public bool Contains(string command)
        {
            return command.Contains(this.Name);
        }

       

        
    }
}
