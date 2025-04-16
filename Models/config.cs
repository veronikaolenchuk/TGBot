using System;
namespace TGBot.Models
{
    public static class config
    {
        public static string token { get; set; } = "{BotToken}";
        public static string url { get; set; } = "https://bottelega.azurewebsites.net";
        public static string hook { get; set; } = url + "/api/message/update";
        public static string adress { get; set; } = "https://webapitg.azurewebsites.net/api/";

    }
}
