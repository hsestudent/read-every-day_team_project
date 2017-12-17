using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Read_every_day
{
    public class DataResult
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }
}
