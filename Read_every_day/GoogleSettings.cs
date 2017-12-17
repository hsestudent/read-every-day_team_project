using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Read_every_day
{
    class GoogleSettings
    {
        private const string Key_google = @"AIzaSyAPfTPDzfa7zYNBvtHvFpVfW3VEktCHUxs";
        private const string _engineID = "003561099360934221795:rnqrayaopko";
        private static string GetLink(string input) => $"https://www.googleapis.com/customsearch/v1?cx={_engineID}&q={input}&searchType=image&key={Key_google}";

        public static async Task<Item[]> GetResult(string input)
        {
            using (HttpClient client = new HttpClient())
            {
                var data = await client.GetStringAsync(GetLink(input));
                var result = JsonConvert.DeserializeObject<DataResult>(data);
                return result.Items;
            }

        }
    }
}
