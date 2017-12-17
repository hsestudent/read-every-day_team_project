using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read_every_day
{
    public static class AppSettings
    {
        public static string Url { get; set; } = "http://t.me/Read_every_dayBot";

        public static string Url_google { get; set; } = "https://cse.google.com/cse/publicurl?cx=003561099360934221795:rnqrayaopko";

        public static string Name { get; set; } = "Read every day_bot";

        public static string Token { get; set; } = "470503687:AAEr92OmdRUB223xhuILOYwekP0kyrMksh0";

        public static string Key_google = @"AIzaSyAPfTPDzfa7zYNBvtHvFpVfW3VEktCHUxs";

        public static int LastUpdateId = 0;
    }
}
