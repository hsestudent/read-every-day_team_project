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
using Google.Apis.Services;

namespace Read_every_day
{
    class Program
    {
        private static Google.Apis.Services.BaseClientService client;
        static void Main(string[] args)
        {
            while (true)
            {
                GetUpdates();
                Thread.Sleep(1000);
            }
        }
        static void GetUpdates()
        {
            using (var webClient = new WebClient())
            {
                Console.WriteLine("Запрос обновления (0)", AppSettings.LastUpdateId + 1);
                string response = webClient.DownloadString("https://api.telegram.org/bot" + AppSettings.Token + "/getUpdates" + "?offset=" + (AppSettings.LastUpdateId + 1));
                var N = JSON.Parse(response);
                foreach (JSONNode r in N["result"].AsArray)
                {
                    AppSettings.LastUpdateId = r["update_id"].AsInt;
                    Console.WriteLine("Пришло сообщение: (0)", r["message"]["text"]);
                    SendMessage("Ща бы к сессии готовиться...", r["message"]["chat"]["id"].AsInt);
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
                webClient.UploadValues("https://api.telegram.org/bot" + AppSettings.Token + "/sendMessage", pars);
            }
        }

        string query = "Your query";

        //var svc = new Google.Apis.CustomSearch.v1.CustomsearchService(new BaseClientService.Initializer { ApiKey = AppSettings.Key_google });
        //var listRequest = svc.Cse.List(query);

        //listRequest.Cx = cx;
        //    var search = listRequest.Fetch();

        //    foreach (var result in search.Items)
        //    {
        //        Response.Output.WriteLine("Title: {0}", result.Title);
        //        Response.Output.WriteLine("Link: {0}", result.Link);
        //    }
    }
}
