using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettleApi.Models.Merchant
{  
    public class MerchantInfo
    {
        [JsonProperty("has_secret")]
        public bool HasSecret { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("key_type")]
        public string KeyType { get; set; }

        [JsonProperty("netmask")]
        public string Netmask { get; set; }

        [JsonProperty("pubkey")]
        public string Pubkey { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }        
    }
}

