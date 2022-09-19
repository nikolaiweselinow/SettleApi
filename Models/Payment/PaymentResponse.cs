using Newtonsoft.Json;

namespace SettleApi.Models.Payment
{
    public class PaymentResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
