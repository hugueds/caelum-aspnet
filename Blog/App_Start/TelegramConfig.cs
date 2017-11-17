using Blog.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Blog.App_Start
{
    public static class TelegramConfig
    {

        public static TelegramBotClient Bot;
        private static string key = ConfigurationManager.AppSettings["BotAPIKey"];

        public static void RegisterBot()
        {
            Bot = new TelegramBotClient(key);
            Debug.WriteLine(key);
            Bot.StartReceiving();
            Bot.OnMessage += Bot_OnMessage;
        }

        private async static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            User u = e.Message.From;
            if (e.Message.Text == "/start")
            {
                await Bot.SendTextMessageAsync(u.Id, "Olá, " + u.FirstName + "! Como posso ajuda-lo?");
            }

            if (e.Message.Text == "/publish")
            {
                PostController p = new PostController();

            }


        }
    }
}