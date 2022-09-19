using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SettleApi.Models.Payment
{
    public class Meta
    {
        [JsonProperty("seqno")]
        public int Seqno { get; set; }

        [JsonProperty("labels")]
        public object[] Labels { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }
    }

    public class PaymentCallback
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}

