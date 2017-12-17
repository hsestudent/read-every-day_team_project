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
        //private static Google.Apis.Services.BaseClientService client;
        static void Main(string[] args)
        {
            while (true)
            {
                BotSettings.GetUpdates();
                Thread.Sleep(1000);
            }
        }



        //string query = "Your query";

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
