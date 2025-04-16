using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TGBot.Client;
using TGBot.Responce;
using TGBot.Response;

namespace TGBot.ExecuteBot
{
    public class Execute
    {
        public static async Task Favorite(Message message, TelegramBotClient client, ApiClient apiClient)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            string name = chatId.ToString();
            var player = await apiClient.ShowPlayer(name);
            var hero = await apiClient.ShowHero(name);
            var team = await apiClient.ShowTeam(name);
            var match = await apiClient.ShowMatch(name);
            if(match!=null)
            {
                string text = $"Favorite match:\n {match.Name}\n begin at:{match.Begin_at}";
                await client.SendTextMessageAsync(chatId, text);
            }
            if (hero != null)
            {
                string text = $"Favorite hero:\n{hero.localized_name}";

                await client.SendTextMessageAsync(chatId, text);
                await client.SendPhotoAsync(chatId, hero.image);

            }
            if (player != null)
            {
                string text = $"Favorite player:\n{player.Name}";
                await client.SendTextMessageAsync(chatId,text);
                await client.SendPhotoAsync(chatId, player.image);

            }
            if (team != null)
            {
                string text = $"Favorite team:\n{team.Name}";
                await client.SendTextMessageAsync(chatId, text);
                await client.SendPhotoAsync(chatId, team.image);

            }
        }

        public static async Task SendEexute(Message message, TelegramBotClient client, ApiClient apiClient)
        {
            string name = message.Text;
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
           
            if(message.Text=="/showmatches")
            {
                var matches = await apiClient.ListOfMatch();

                string match_1 = $"Match:{matches[0].name} \nstart at: {matches[0].begin_at}\n id: {matches[0].id}";
                string match_2 = $"Match:{matches[1].name}\n start at: {matches[1].begin_at}\n id: {matches[1].id}";
                await client.SendTextMessageAsync(chatId, match_1);
                await client.SendTextMessageAsync(chatId, match_2);
                


            }
            if (message.ReplyToMessage.Text != null)
            {

                switch (message.ReplyToMessage.Text)
                {
                    case "Enter name of player":
                        var player = await apiClient.FindPlayer(name);
                        await client.SendPhotoAsync(chatId, player.image, player.name);
                        
                        await client.SendTextMessageAsync(chatId, "");
                        break;
                    case "Enter name of team":
                        var team = await apiClient.FindTeam(name);
                        await client.SendPhotoAsync(chatId, team.image, team.Name);

                        break;
                    case "Enter name of hero":
                        var hero = await apiClient.FindHero(name);
                        await client.SendPhotoAsync(chatId, hero.image, hero.localized_name);
                        break;
                    case "Enter id of match":
                        var matches = await apiClient.MatchById(name);
                        string match = $"Match:{matches.name}\n start at: {matches.begin_at}\n id: {matches.id}";
                        await client.SendTextMessageAsync(chatId, match);

                        break;
                    case "Enter favotite name of team":
                        var fvteamresponce = await apiClient.FindTeam(name);
                        var fvteam = new TeamsResponseData
                        {
                            User = chatId.ToString(),
                            Name=fvteamresponce.Name,
                            image=fvteamresponce.image
                        };
                        await apiClient.SaveTeam(fvteam);
                        await client.SendTextMessageAsync(chatId,"Added successfully");
                        break;

                    case "Enter favotite name of player":
                        var fvplayerresponce = await apiClient.FindPlayer(name);
                        var fvplayer = new PlayerResponceData
                        {
                            User = chatId.ToString(),
                            Name = fvplayerresponce.name,
                            image = fvplayerresponce.image
                        };
                        await apiClient.SavePlayer(fvplayer);
                        await client.SendTextMessageAsync(chatId, "Added successfully");
                        break;

                        
                    case "Enter favotite id of match":
                        var fvmatchreponce = await apiClient.MatchById(name);
                        var fvmatch = new MatchResponceData
                        {
                            User = chatId.ToString(),
                            Name = fvmatchreponce.name,
                            Begin_at = fvmatchreponce.begin_at,
                            id= fvmatchreponce.id,

                        };
                        await apiClient.SaveMatch(fvmatch);
                        await client.SendTextMessageAsync(chatId, "Added successfully");
                        

                        break;
                    case "Enter favotite name of hero":
                        var fvheroresponce = await apiClient.FindHero(name);
                        var fvhero = new HeroResponceData
                        {
                            User = chatId.ToString(),
                            name= fvheroresponce.name,
                            localized_name= fvheroresponce.localized_name,
                            image= fvheroresponce.image
                        };
                        await apiClient.SaveHero(fvhero);
                        await client.SendTextMessageAsync(chatId, "Added successfully");
                        break;





                }
            }
            
        }

        
    }
}
