using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettleApi.Models.Payment
{
    public class PaymentCapture
    {
        [JsonProperty("action")]
        public string Action { get; set; }
    }
}
