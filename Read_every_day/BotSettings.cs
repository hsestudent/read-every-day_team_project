using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleJSON;
using System.Threading;
using System.Net;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.ResponseObjects;
using TelegramBot;
using Newtonsoft.Json.Serialization;

namespace Read_every_day
{
    public class BotSettings
    {        
        private const string Name = "Read every day_bot";
        private const string Token = "470503687:AAEr92OmdRUB223xhuILOYwekP0kyrMksh0";
        private static int LastUpdateId = 0;
       // private static string answer = "";

        public static void GetUpdates()
        {
            using (var webClient = new WebClient())
            {
                Console.WriteLine("Запрос обновления (0)", LastUpdateId + 1);
                string response = webClient.DownloadString("https://api.telegram.org/bot" + Token + "/getUpdates" + "?offset=" + (LastUpdateId + 1));
                var N = JSON.Parse(response);
                foreach (JSONNode r in N["result"].AsArray)
                {
                    LastUpdateId = r["update_id"].AsInt;
                    Console.WriteLine("Пришло сообщение: {0}", r["message"]["text"]);

                    var SearchResult = GoogleSettings.GetResult(r["message"]["text"]);

                    if (SearchResult != null)
                    {
                        SendMessage("Вот результат:", r["message"]["chat"]["id"].AsInt);
                        //SendMessage(SearchResult.Item.Link, r["message"]["chat"]["id"].AsInt);
                    }               
                }
            }
        }

        static void SendMessage(string message, int chatid)
        {
            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection
                {
                    { "text", message },
                    { "chat_id", chatid.ToString() }
                };
                webClient.UploadValues("https://api.telegram.org/bot" + Token + "/sendMessage", pars);
            }
        }
    }
}
