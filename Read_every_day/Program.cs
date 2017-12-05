using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleJSON;
using System.Threading;
using System.Net;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Read_every_day
{
    class Program
    {
        public static string Token = @"470503687:AAEr92OmdRUB223xhuILOYwekP0kyrMksh0";
        public static int LastUpdateId = 0;
        static void Main(string[] args)
        {
            while (true)
            {
                GetUpdates();
                Thread.Sleep(1000);
            }
            Console.WriteLine("Hello our telegram bot user! ");
            Console.WriteLine("Check the repository");
        }
        static void GetUpdates()
        {
            using (var webClient = new WebClient())
            {
                Console.WriteLine("Запрос обновления (0)", LastUpdateId+1);
                string response = webClient.DownloadString("https://api.telegram.org/bot" + Token + "/getUpdates" + "?offset=" + (LastUpdateId + 1));
                var N = JSON.Parse(response);
                foreach (JSONNode r in N["result"].AsArray)
                {
                    LastUpdateId = r["update_id"].AsInt;
                    Console.WriteLine("Пришло сообщение: (0)",r["message"]["text"]);
                    SendMessage("Ща бы к сессии готовиться...", r["message"]["chat"]["id"].AsInt);
                }
            }
        }
        static void SendMessage(string message, int chatid)
        {
            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection();
                pars.Add("Text", message);
                pars.Add("chat_id", chatid.ToString());
                webClient.UploadValues("https://api.telegram.org/bot"+Token+"/sendMessage", pars)
            }
        }
    }
}
