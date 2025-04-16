using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using TGBot.ExecuteBot;
using TGBot.Client;
using TGBot.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TGBot.Controllers
{
    [Route(@"api/message/update")]
    [ApiController]

    public class MessageController : Controller
    {
        private readonly ApiClient _apiClient;
        private readonly ILogger<MessageController> _logger;
        public MessageController(ILogger<MessageController> logger,ApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }


        [HttpPost]

        public async Task<OkResult> Update([FromBody] Update update)
        {

            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();

            if (message.Text == null)
            {
                return Ok();
            }

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, client);

                    break;
                }
            }
            if(message.Text=="/showfavorite")
            {
                Execute.Favorite(message, client, _apiClient);

            }
            if (message.Text == "/showmatches")
            {
                 Execute.SendEexute(message, client, _apiClient);
                
            }
            try
            {
                if (message.ReplyToMessage != null)
                {
                    await Execute.SendEexute(message, client, _apiClient);
                }
            }
            catch (Exception e)
            {
                await client.SendTextMessageAsync(update.Message.Chat.Id, "Not found such name");
            }

            return Ok();
        }

    }
}

