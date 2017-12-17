﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Read_every_day
{
    public class Item
    {
        [JsonProperty("snippet")]
        public string Snippet { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
    }
}