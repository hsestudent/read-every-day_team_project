﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;


namespace Read_every_day
{
    public static class Bot
    {
        private static TelegramBotClient  client;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands
        {
            get => commandsList.AsReadOnly();
        }

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }
            commandsList = new List<Command>
            {
                new HelloCommand()
            };
            //others command initialization;
            client = new TelegramBotClient(AppSettings.Token);
            await client.SetWebhookAsync("");
            return client;
        }

    }
}
